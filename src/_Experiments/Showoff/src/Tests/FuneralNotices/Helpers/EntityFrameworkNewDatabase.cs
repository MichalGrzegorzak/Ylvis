using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Text;
using Showoff.Core.Features.Extensions;
using Showoff.Notices.DAL.Context;
using Showoff.Notices.DAL.Entities;
using Showoff.Notices.DAL.Enums;
using NUnit.Framework;

namespace Showoff.Integration.Tests.FuneralNotices.Helpers
{
    public class EntityFrameworkNewDatabase : NoticesStructureInitBase
    {
        protected FuneraNoticeBuilder noticeBuilder = new FuneraNoticeBuilder();

        [TestFixtureSetUp]
        public new void Init()
        {
            base.Init();

            //FULL SQL
            //var initializer = new DropDatabaseInitializer<NoticesContext>(Seed);
            //Database.SetInitializer(initializer);
            //initializer.InitializeDatabase(new NoticesContext());

            //DbMigrationsConfiguration conf = new DbMigrationsConfiguration();
            //conf.AutomaticMigrationsEnabled = true;
            Database.SetInitializer(new DropDatabaseAlways());
        }

        [TestFixtureTearDown]
        public virtual void Cleanup()
        {
        }

        protected virtual void Seed(NoticesContext context)
        {
            var notice = new FuneralNotice(1, "test", "test")
            {
                MemorialId = 1,
                ParentBranchId = "1",
                CedarCode = "cedarCode",
                BranchId = "1",
                KnownAs = "knownAs",
                Obituary = "Obituary",
                Source = SourceType.PERMAVITA,
                DateOfDeath = DateTime.UtcNow,
                DateOfFuneral = DateTime.UtcNow,
            };

            try
            {
                context.FuneralNotices.Add(notice);
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var eve in e.EntityValidationErrors)
                {
                    builder.AppendLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:".Frmt(
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        builder.AppendLine("- Property: \"{0}\", Error: \"{1}\"".Frmt(ve.PropertyName, ve.ErrorMessage));
                    }
                }
                Console.Write(builder.ToString());
                throw;
            }

        }

    }
}
