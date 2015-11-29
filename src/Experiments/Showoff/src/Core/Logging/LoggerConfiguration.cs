using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Showoff.Core.Configuration;
using Showoff.Notices.DAL.Enums;

namespace Showoff.Notices.BusinessLogic.Logging
{
    public class LoggerConfiguration : ConfigurationBase<LoggerConfiguration>
    {
        public override void Initialize(IConfigurationManager configuration)
        {
            Configuration = configuration;

            NoticesIndexName = ReadAppSettingsEntry<string>("NoticesIndexName");
            NoticesIndexUrl = ReadAppSettingsEntry<string>("NoticesIndexUrl");
            EpiFindTTL = ReadAppSettingsEntry<int>("EpiFindTTL", 7);
            NoticesTimeToLeave = new TimeSpan(EpiFindTTL, 0, 0, 0); //for 7 days

            IsElmahLoggingEnabled = ReadAppSettingsEntry<bool>("IsElmahLoggingEnabled", true);
            IsDbLoggingEnabled = ReadAppSettingsEntry<bool>("IsDbLoggingEnabled", true);
            StatesForElmah = ReadEnumListValues<AuditState>("StatesForElmah");
            LogEveryStateToDb = ReadAppSettingsEntry<bool>("LogEveryStateToDb", true);
            StatesForDbAudit = LogEveryStateToDb
                ? ListAllEnumValues<AuditState>()
                : ReadEnumListValues<AuditState>("StatesForDbAudit");
        }

        public TimeSpan NoticesTimeToLeave { get; set; }

        public bool IsElmahLoggingEnabled { get; private set; }
        public bool IsDbLoggingEnabled { get; private set; }
        public bool LogEveryStateToDb { get; private set; }
        public int EpiFindTTL { get; private set; }
        public List<AuditState> StatesForElmah { get; private set; }
        public List<AuditState> StatesForDbAudit { get; private set; }

        public string NoticesIndexName { get; private set; }
        public string NoticesIndexUrl { get; private set; }
    }
}
