using Showoff.Notices.DAL.Context;
using Showoff.Notices.DAL.Entities;
using Showoff.Notices.DAL.Enums;

namespace Showoff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstRecord : DbMigration
    {
        public override void Up()
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

            using (var context = new NoticesContext())
            {
                context.FuneralNotices.Add(notice);
            }
        }
        
        public override void Down()
        {
        }
    }
}
