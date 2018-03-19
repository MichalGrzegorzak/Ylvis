using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using Showoff.Integration.Tests.FuneralNotices.Helpers;
using Showoff.Notices.BusinessLogic.Logging;
using Showoff.Notices.DAL.Context;
using Showoff.Core.Configuration;
using Showoff.Integration.Tests.FuneralNotices.Elmah;
using Showoff.Integration.Tests.FuneralNotices.Helpers;
using Showoff.Notices.BusinessLogic;

using Showoff.Notices.BusinessLogic.Logging;
using Showoff.Notices.DAL.Context;
using Showoff.Notices.DAL.Entities;
using Showoff.Notices.DAL.Enums;
using Moq;
using NUnit.Framework;

namespace Showoff.Integration.Tests.FuneralNotices
{
    [TestFixture, RequiresSTA]
    public class EF_Verify_Logger : EntityFrameworkNewDatabase
    {
        private NoticeLogger logger;
        private NoticesContext ctx;

        [SetUp]
        public void Setup()
        {
            LoggingHelper.PointLoggerToElmahDb();
            //excluded ELMAH
            ///LoggingHelper.ClearElmahLogs();
            LoggingHelper.EnableLoggingAll();

            ctx = new NoticesContext();
            logger = new NoticeLogger();
        }

        private void AddNotice(FuneralNotice notice)
        {
            try
            {
                logger.Log(notice, AuditState.Validated);
                //
                ctx.FuneralNotices.Add(notice);
                ctx.SaveChanges();
                //
                logger.Log(notice, AuditState.SavedToDb);
            }
            catch (Exception ex)
            {
                logger.Log(notice, ex); //should store in Elmah
            }
        }

        [Test]
        public void t01_can_add_auditstates_to_db()
        {
            FuneralNotice notice = noticeBuilder.WithId(3);
            logger.Log(notice, AuditState.Creating);

            AddNotice(notice);

            logger.Log(notice, AuditState.Indexed);
            logger.FlushToDb();

            var results = ctx.AuditLogFuneralNotices
                .Where(x => x.FuneraNoticeId == notice.Id)
                .ToList();

            Assert.AreEqual(4, results.Count());
        }

        //excluded ELMAH
        //[Test]
        //public void t02_should_log_exception_to_elmah()
        //{
        //    FuneralNotice notice = noticeBuilder.WithId(4);
        //    logger.Log(notice, AuditState.Creating);

        //    AddNotice(notice);
        //    AddNotice(notice); //throws Exception, that would log in Elmah
            
        //    var results = LoggingHelper.GetElmahLogs();
        //    Assert.AreEqual(1, results.Count());
        //}

        //excluded ELMAH
        //[Test]
        //public void t03_should_log_to_both_elmah_and_db()
        //{
        //    FuneralNotice notice = noticeBuilder.WithId(5);
        //    logger.Log(notice, AuditState.Creating);
        //    AddNotice(notice);
        //    logger.FlushToDb();

        //    AddNotice(notice); //throws Exception, that would log in Elmah
        //    logger.FlushToDb();

        //    var results = LoggingHelper.GetElmahLogs();
        //    Assert.AreEqual(1, results.Count());

        //    var dbResults = ctx.AuditLogFuneralNotices.Where(x => x.FuneraNoticeId == notice.Id).ToList();
        //    Assert.AreEqual(5, dbResults.Count());
        //}

        [Test]
        public void t04_log_twice_same_audit_prevention()
        {
            FuneralNotice notice = noticeBuilder.WithId(6);
            logger.Log(notice, AuditState.Creating);
            AddNotice(notice);
            logger.Log(notice, AuditState.Validated);
            logger.Log(notice, AuditState.Validated);
            logger.Log(notice, AuditState.Validated);
            logger.FlushToDb();

            var dbResults = ctx.AuditLogFuneralNotices.Count(x => x.FuneraNoticeId == notice.Id);
            Assert.AreEqual(4, dbResults);
        }

        [Test]
        public void t05_should_store_validation_error_in_db()
        {
            string validationError = "Property X failed";

            FuneralNotice notice = noticeBuilder.WithId(7);
            logger.Log(notice, AuditState.Creating);
            logger.Log(notice, AuditState.ValidationFailed, validationError);
            logger.FlushToDb();

            
            var audit = ctx.AuditLogFuneralNotices.Where(x => x.FuneraNoticeId == notice.Id).ToList().LastOrDefault();
            Assert.AreEqual(audit.Error, validationError);
        }

        [Test]
        public void t06_should_store_validation_error_in_db_for_exception()
        {
            string validationError = "Property X failed";

            FuneralNotice notice = noticeBuilder.WithId(8);
            logger.Log(notice, new DbEntityValidationException(validationError));
            logger.FlushToDb();


            var audit = ctx.AuditLogFuneralNotices.Where(x => x.FuneraNoticeId == notice.Id).ToList().LastOrDefault();
            Assert.AreEqual(validationError, audit.Error);
        }

        [Test]
        public void t07_should_store_validation_error_in_could_not_create_notice()
        {
            string validationError = "Property X failed";

            FuneralNotice notice = null;
            logger.Log(notice, new DbEntityValidationException(validationError));
            logger.FlushToDb();


            var audit = ctx.AuditLogFuneralNotices.Where(x => x.FuneraNoticeId == -1).ToList().LastOrDefault();
            Assert.AreEqual(validationError, audit.Error);
        }
    }
}
