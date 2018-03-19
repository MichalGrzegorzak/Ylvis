using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using EPiServer.Find;
using Showoff.Core.Configuration;
using Showoff.Integration.Tests.FuneralNotices.Elmah;
using Showoff.Integration.Tests.FuneralNotices.Helpers;
using Showoff.Notices.BusinessLogic.EpiFind;
using Showoff.Notices.BusinessLogic.Logging;
using Showoff.Notices.DAL.Context;
using Showoff.Notices.DAL.Entities;
using Showoff.Notices.DAL.Enums;
using Moq;
using NUnit.Framework;
using Newtonsoft.Json;
using StructureMap;

namespace Showoff.Web.Tests.Core
{
    [TestFixture, RequiresSTA]
    public class Verify_NoticesIndexer : EntityFrameworkNewDatabase
    {
        private FuneraNoticeBuilder noticeBuilder = new FuneraNoticeBuilder();
        private NoticesIndexer indexer;
        //private Dictionary<Int64, FuneralNotice> _dictionary = new Dictionary<Int64, FuneralNotice>();
        //private Mock<IClient> clientNotice;
        private IClient clientNotice;

        [SetUp]
        public void Startup()
        {
            LoggingHelper.EnableLoggingAll();

            var noticeLogger = new Mock<INoticeLogger>();
            noticeLogger.Setup(x => x.Log(It.IsAny<FuneralNotice>(), It.IsAny<AuditState>(), It.IsAny<string>()));
            noticeLogger.Setup(x => x.Log(It.IsAny<FuneralNotice>(), It.IsAny<Exception>()));
            indexer = new NoticesIndexer(noticeLogger.Object);

            //clientNotice = new Mock<IClient>();
            //clientNotice.Setup(x => x.Index(It.IsAny<FuneralNotice>())).Callback<FuneralNotice>(x=> _dictionary.Add(x.Id, x));
            clientNotice = new Client(LoggingHelper.IndexNoticeUrl, LoggingHelper.IndexNoticeName);

            indexer.CreateClients(clientNotice);

            //WARNING
            //indexer.ClearAllNoticesInIndex();
        }

        [Test]
        public void t01_should_add_get_from_Index()
        {
            FuneralNotice fn = noticeBuilder.WithId(1);
            indexer.Add(fn);
            var result = indexer.GetNotice(fn);
            
            Assert.That(result.FirstNames, Is.EqualTo(fn.FirstNames));
        }

        [Test]
        public void t02_can_delete_from_Index()
        {
            FuneralNotice fn = noticeBuilder.WithId(2).WithSurname("unique_surname");
            indexer.Add(fn);
            indexer.Delete(fn);
            var result = indexer.GetNotice(fn);
            Assert.That(result, Is.EqualTo(null));
        }

        [Test]
        public void t03_Update_Index()
        {
            FuneralNotice fn = noticeBuilder.WithId(3);
            
            //add
            indexer.Add(fn);
            var result1 = indexer.GetNotice(fn);
            Assert.That(result1.NoticeState, Is.EqualTo(NoticeState.Created));
            
            //delete
            indexer.Delete(fn);
            var result2 = indexer.GetNotice(fn);
            Assert.That(result2, Is.Null);

            //update
            FuneralNotice fn1 = noticeBuilder.WithId(3);
            fn1.NoticeState = NoticeState.Updated;
            fn1.Obituary = "ObituaryObituaryObituary";
            indexer.Add(fn1);
            var result3 = indexer.GetNotice(fn1);
            
            //Assert.That(result3.KnownAs, Is.Null); //is marked as ignored for Find
            Assert.That(result3.Obituary, Is.EqualTo("ObituaryObituaryObituary"));
        }

        [Test]
        public void t04_Indexing_enums()
        {
            FuneralNotice fn = noticeBuilder.WithId(3);
            fn.NoticeState = NoticeState.Deleted;

            //add
            indexer.Add(fn);
            var result1 = indexer.GetNotice(fn);
            Assert.That(result1.NoticeState, Is.EqualTo(NoticeState.Deleted));

            //update
            FuneralNotice fn1 = noticeBuilder.WithId(3);
            fn1.NoticeState = NoticeState.Updated;
            indexer.Add(fn1);
            var result2 = indexer.GetNotice(fn1);

            Assert.That(result2.NoticeState, Is.EqualTo(NoticeState.Updated));
        }


        [Test]
        [Explicit] //not working -> no idea
        public void t05_TTL_Index()
        {
            LoggerConfiguration.Inst.NoticesTimeToLeave = new TimeSpan(0, 0, 5); //5 sec

            FuneralNotice fn = noticeBuilder.WithId(4);
            fn.OnlineMemorialUrl = string.Empty;
            indexer.Add(fn);
            var result1 = indexer.GetNotice(fn);
            Assert.That(result1.Id, Is.EqualTo(fn.Id));

            Thread.Sleep(15 * 1000);

            var result2 = indexer.GetNotice(fn);
            
            Assert.That(result2, Is.Null);
        }

        [Test]
        public void t06_Reindex_all()
        {
            var date = DateTime.UtcNow.AddDays(-8); //too old
            FuneralNotice fn1 = noticeBuilder.WithId(5).WithDateOfFunerale(date); //funeral
            fn1.OnlineMemorialUrl = string.Empty;
            FuneralNotice fn2 = noticeBuilder.WithId(6).WithDateOfFunerale(date); //online

            using (var ctx = new NoticesContext())
            {
                ctx.FuneralNotices.Add(fn1);
                ctx.FuneralNotices.Add(fn2);
                ctx.SaveChanges();
            }
            
            indexer.Add(fn1);
            indexer.Add(fn2);
            indexer.ReIndexAll();

            var result = indexer.ReindexedCount;

            Assert.That(result, Is.EqualTo(2));
        }
        

        /////A helper for a real Index test
        [Test][Explicit]
        public void t07_SeedIndex()
        {
            indexer.ClearAllNoticesInIndex();
            LoggerConfiguration.Inst.NoticesTimeToLeave = new TimeSpan(0,1,0);

            int id = 2;
            using (var ctx = new NoticesContext())
            {
                for (int i = 0; i < 999; i++)
                {
                    FuneralNotice fn = noticeBuilder.WithId(2 + i);
                    fn.OnlineMemorialUrl = string.Empty;
                    ctx.FuneralNotices.Add(fn);
                }
                ctx.SaveChanges();
            }

            
            Assert.That(1, Is.EqualTo(1));

            indexer.ReIndexAll();
            var result = indexer.ReindexedCount;
            Assert.That(result, Is.GreaterThan(2));
        }

        //[Test][Explicit]
        //public void t08_ReadWholeIndex()
        //{
        //    FuneralNotice fn1 = noticeBuilder.WithId(5); //funeral
        //    fn1.OnlineMemorialUrl = string.Empty;
        //    FuneralNotice fn2 = noticeBuilder.WithId(6); //online
        //    indexer.Add(fn1);
        //    indexer.Add(fn2);

        //    var search = indexer.Query();
        //    var r = search.For("ObituaryObituary").GetResult().ToList();
        //    int i = r.Count();

        //}


    }


}

