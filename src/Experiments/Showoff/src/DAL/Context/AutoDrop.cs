using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Showoff.Core.Features.Extensions;
using Showoff.Notices.DAL.Entities;
using Showoff.Notices.DAL.Enums;

namespace Showoff.Notices.DAL.Context
{
    public class DropDatabaseAlways : DropCreateDatabaseAlways<NoticesContext>
    {
        public override void InitializeDatabase(NoticesContext context)
        {
            var notice = new FuneralNotice(2, "test2", "test2")
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
                base.InitializeDatabase(context);
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
