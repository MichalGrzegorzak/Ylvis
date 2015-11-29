using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Showoff.Notices.DAL.Entities;
using Showoff.Notices.DAL.Entities;

namespace Showoff.Notices.DAL.Context
{
    public class NoticesContext : DbContext
    {
        public NoticesContext() : base("NoticesContext")
        {
            //Database.SetInitializer((new NoticesInitializer());
        }

        public DbSet<FuneralNotice> FuneralNotices { get; set; }
        public DbSet<AuditFuneralNotice> AuditLogFuneralNotices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //  Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            
            //  FuneralNotice
            modelBuilder.Entity<FuneralNotice>().HasKey(fn => fn.Id)
                .Property(fn => fn.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<FuneralNotice>().Property(fn => fn.FirstNames).HasMaxLength(255);
            modelBuilder.Entity<FuneralNotice>().Property(fn => fn.Surname).HasMaxLength(255);
            modelBuilder.Entity<FuneralNotice>().Property(fn => fn.CedarCode).HasMaxLength(20);
            modelBuilder.Entity<FuneralNotice>().Property(fn => fn.KnownAs).HasMaxLength(20);
            modelBuilder.Entity<FuneralNotice>().Property(fn => fn.SourceString).HasMaxLength(20);
            modelBuilder.Entity<FuneralNotice>().Property(fn => fn.NoticeStateString).HasMaxLength(20);
            
            
            //  AuditLogFuneraNotice
            modelBuilder.Entity<AuditFuneralNotice>().HasKey(a => a.Id)
                .Property(a => a.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<AuditFuneralNotice>().Property(a => a.AuditState).IsRequired();
            modelBuilder.Entity<AuditFuneralNotice>().Property(a => a.AuditStateString).IsRequired();
        }


    }

}

