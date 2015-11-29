using System;
using System.Data.Entity;
using System.Linq;
using Showoff.Notices.DAL.Entities;

namespace Showoff.Notices.DAL.Context
{
    public static class NoticesContextExtensions
    {
        public static AuditFuneralNotice GetLast(this DbSet<AuditFuneralNotice> auditNotices, Int64 id)
        {
            return auditNotices.Where(x => x.FuneraNoticeId == id)
                                       .OrderByDescending(x => x.Id)
                                       .FirstOrDefault();
        }

        public static FuneralNotice GetLast(this DbSet<FuneralNotice> notices)
        {
            return notices.OrderByDescending(x => x.ModifiedDate).FirstOrDefault();
        }
    }
}
