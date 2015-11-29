using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Showoff.Core.Configuration;
using Showoff.Core.Features.Extensions;

using Showoff.Notices.BusinessLogic.Logging;
using Showoff.Notices.DAL.Context;
using Showoff.Notices.DAL.Enums;
using Moq;

namespace Showoff.Integration.Tests.FuneralNotices.Elmah
{
    public static class LoggingHelper
    {
        public const string IndexNoticeUrl = "http://es-api01.episerver.com/HDomMTm6bdfUibkboZH0uMTpmO9NU0JH";
        public const string IndexNoticeName = "notices";

        public static Mock<IConfigurationManager> EnableLoggingAll()
        {
            var allStates = Enum.GetValues(typeof(AuditState)).OfType<AuditState>().ToList();
            var appSettings = new NameValueCollection
            {
                {"IsElmahLoggingEnabled", "true"},
                {"IsDbLoggingEnabled", "true"},

                {"NoticesIndexName", IndexNoticeName},
                {"NoticesIndexUrl", IndexNoticeUrl},

                {"StatesForElmah", allStates.ToStringList()},
                {"StatesForDbAudit", allStates.ToStringList()}
            };

            //setup mocked LoggerConfiguration
            var configurationManager = new Mock<IConfigurationManager>();
            configurationManager.SetupGet(c => c.AppSettings).Returns(appSettings);
            LoggerConfiguration.Inst.Initialize(configurationManager.Object);

            return configurationManager;
        }

        public static void PointLoggerToElmahDb()
        {
            //ElmahExtension.ConnectionString = @"Data Source=(local);Initial Catalog=Elmah;Integrated Security=False;User ID=dbUser;Password=Pa$$;MultipleActiveResultSets=True";
        }

        //public static void ClearElmahLogs()
        //{
        //    using (ElmahContext ctx = new ElmahContext())
        //    {
        //        var results = GetElmahLogs(ctx);
        //        ctx.ELMAH_Error.RemoveRange(results);
        //        ctx.SaveChanges();
        //    }
        //}

        //public static List<ELMAH_Error> GetElmahLogs(ElmahContext ctx = null)
        //{
        //    ctx = ctx ?? new ElmahContext();
        //    var results = ctx.ELMAH_Error.Where(x => x.Application == ElmahExtension.ElmahApplicationName).ToList();
        //    return results;
        //}

        
    }
}
