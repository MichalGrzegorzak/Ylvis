namespace Showoff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialConfiguration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditFuneralNotice",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FuneraNoticeId = c.Long(nullable: false),
                        Entry = c.DateTime(nullable: false),
                        AuditState = c.Int(nullable: false),
                        AuditStateString = c.String(nullable: false, maxLength: 4000),
                        Error = c.String(maxLength: 4000),
                        MemorialId = c.Long(nullable: false),
                        CedarCode = c.String(maxLength: 4000),
                        BranchId = c.String(maxLength: 4000),
                        CreateDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        KnownAs = c.String(maxLength: 4000),
                        OnlineMemorialUrl = c.String(maxLength: 4000),
                        DeceasedImageUrl = c.String(maxLength: 4000),
                        ParentBranchId = c.String(maxLength: 4000),
                        Surname = c.String(maxLength: 4000),
                        FirstNames = c.String(maxLength: 4000),
                        DateOfDeath = c.DateTime(nullable: false),
                        DateOfFuneral = c.DateTime(),
                        Obituary = c.String(maxLength: 4000),
                        Source = c.Int(nullable: false),
                        SourceString = c.String(maxLength: 4000),
                        NoticeState = c.Int(nullable: false),
                        NoticeStateString = c.String(maxLength: 4000),
                        ShowDeceasedImage = c.Boolean(nullable: false),
                        RemoveNotice = c.Boolean(nullable: false),
                        FuneralNotice_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FuneralNotice", t => t.FuneralNotice_Id)
                .Index(t => t.FuneralNotice_Id);
            
            CreateTable(
                "dbo.FuneralNotice",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        MemorialId = c.Long(nullable: false),
                        CedarCode = c.String(maxLength: 20),
                        BranchId = c.String(maxLength: 4000),
                        CreateDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        KnownAs = c.String(maxLength: 20),
                        OnlineMemorialUrl = c.String(maxLength: 4000),
                        DeceasedImageUrl = c.String(maxLength: 4000),
                        ParentBranchId = c.String(maxLength: 4000),
                        Surname = c.String(maxLength: 255),
                        FirstNames = c.String(maxLength: 255),
                        DateOfDeath = c.DateTime(nullable: false),
                        DateOfFuneral = c.DateTime(),
                        Obituary = c.String(maxLength: 4000),
                        Source = c.Int(nullable: false),
                        SourceString = c.String(maxLength: 20),
                        NoticeState = c.Int(nullable: false),
                        NoticeStateString = c.String(maxLength: 20),
                        ShowDeceasedImage = c.Boolean(nullable: false),
                        RemoveNotice = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuditFuneralNotice", "FuneralNotice_Id", "dbo.FuneralNotice");
            DropIndex("dbo.AuditFuneralNotice", new[] { "FuneralNotice_Id" });
            DropTable("dbo.FuneralNotice");
            DropTable("dbo.AuditFuneralNotice");
        }
    }
}
