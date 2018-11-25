using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Showoff.Integration.Tests.FuneralNotices.Helpers;
using Showoff.Notices.DAL;
using Showoff.Notices.DAL.Context;
using Showoff.Notices.DAL.Entities;
using Showoff.Notices.DAL.Enums;
using NUnit.Framework;

namespace Showoff.Integration.Tests.FuneralNotices
{
    [TestFixture]
    public class EF_Verify_Entities : EntityFrameworkNewDatabase
    {
        [Test]
        public void t01_verify_if_can_create_db()
        {
            int result;
            using (NoticesContext ctx = new NoticesContext())
            {
                FuneralNotice notice = noticeBuilder.WithId(3);
                
                ctx.FuneralNotices.Add(notice);
                result = ctx.SaveChanges();
            }
            Assert.IsTrue(result == 1);
        }

        [Test]
        public void t02_should_be_two_notices_already()
        {
            List<FuneralNotice> results;
            using (NoticesContext ctx = new NoticesContext())
            {
                results = ctx.FuneralNotices.Where(x => x.Id > 0).ToList();
            }
            Assert.IsTrue(results.Count == 2);
        }

        [Test]
        public void t03_add_notice_and_auditlog()
        {
            AuditFuneralNotice audit;
            using (NoticesContext ctx = new NoticesContext())
            {
                FuneralNotice notice = noticeBuilder.WithId(4);
                ctx.FuneralNotices.Add(notice);

                audit = new AuditFuneralNotice(notice, AuditState.SavedToDb);
                ctx.AuditLogFuneralNotices.Add(audit);
                int result = ctx.SaveChanges();
                
                Assert.IsTrue(result == 2);
            }
            
            //read
            using (NoticesContext ctx = new NoticesContext())
            {
                audit = ctx.AuditLogFuneralNotices.FirstOrDefault(x => x.Id == 1);
            }
            Assert.IsTrue(audit.Id == 1);
        }

        [Test]
        public void t05_notice_check_enums_trick()
        {
            List<FuneralNotice> result;
            using (NoticesContext ctx = new NoticesContext())
            {
                FuneralNotice notice = noticeBuilder
                    .WithId(5)
                    .WithSourceType(SourceType.RAINBOW);

                ctx.FuneralNotices.Add(notice);
                ctx.SaveChanges();

                result = ctx.FuneralNotices
                    .Where(x => x.Source == SourceType.RAINBOW)
                    .ToList();
            }
            
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.First().SourceString, Is.EqualTo(SourceType.RAINBOW.ToString()) );
        }

        [Test]
        public void t06_audits_verify_getLast()
        {
            AuditFuneralNotice result;
            using (NoticesContext ctx = new NoticesContext())
            {
                FuneralNotice notice = noticeBuilder
                    .WithId(6);

                var audit1 = new AuditFuneralNotice(notice, AuditState.Creating);
                var audit2 = new AuditFuneralNotice(notice, AuditState.IndexingFailed);

                ctx.FuneralNotices.Add(notice);
                ctx.AuditLogFuneralNotices.AddRange(new[] { audit1, audit2 });
                ctx.SaveChanges();
            }
            using (NoticesContext ctx = new NoticesContext())
            {
                result = ctx.AuditLogFuneralNotices.GetLast(6);
            }

            Assert.That(result.AuditState, Is.EqualTo(AuditState.IndexingFailed) );
        }
    }



}
