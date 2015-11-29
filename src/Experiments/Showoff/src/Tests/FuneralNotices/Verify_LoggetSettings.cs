using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Showoff.Core.Configuration;
using Showoff.Core.Features.Extensions;
using Showoff.Notices.BusinessLogic.Logging;
using Showoff.Notices.DAL.Enums;
using Moq;
using NUnit.Framework;

namespace Showoff.Integration.Tests.FuneralNotices
{
    [TestFixture]
    public class Verify_LoggetSettings
    {
        private Mock<IConfigurationManager> _configurationManager;
        private NameValueCollection _appSettings;
        private LoggerConfiguration _config = LoggerConfiguration.Inst;

        [SetUp]
        public void MockAppSettings()
        {
            var stateListElmah = new List<AuditState>(new[] { AuditState.Unknown, AuditState.DbError, AuditState.ValidationFailed });
            var dbListElmah = new List<AuditState>(new[] { AuditState.Creating, AuditState.Updateing, AuditState.Validated, AuditState.SavedToDb  });

            _appSettings = new NameValueCollection
            {
                {"IsElmahLoggingEnabled", "true"},
                {"IsDbLoggingEnabled", "true"},
                //{"EpiFindTTL", "55"},
                {"StatesForElmah", stateListElmah.ToStringList()},
                {"StatesForDbAudit", dbListElmah.ToStringList()}
            };
            _configurationManager = new Mock<IConfigurationManager>();
            _configurationManager.SetupGet(c => c.AppSettings).Returns(_appSettings);
            _config.Initialize(_configurationManager.Object);
        }

        private void SetKeyValue(string key, object value)
        {
            _appSettings[key] = value.ToString();
            _config.Initialize(_configurationManager.Object);
        }

        [Test]
        public void t01_check_mocking_appSettings_works()
        {
            bool result = _config.IsElmahLoggingEnabled;
            Assert.AreEqual(result, true);

            SetKeyValue("IsElmahLoggingEnabled", false); //can manually change value inside appSettings

            result = _config.IsElmahLoggingEnabled;
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void t02_can_parse_elmah_states_from_mock()
        {
            var expect = new List<AuditState> {AuditState.Unknown, AuditState.DbError, AuditState.ValidationFailed};

            var result = _config.StatesForElmah;
            Assert.That(result, Is.EqualTo(expect));
        }

        [Test]
        public void t03_should_read_default_value_if_missing_in_appSettings_from_mock()
        {
            int result = _config.EpiFindTTL;
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void t04_can_parse_elmah_states_from_config_file()
        {
            _config.Initialize(new ConfigurationManagerWrapper()); //normally

            var expect = new List<AuditState>
            {
                AuditState.Unknown,
                AuditState.DbError,
                AuditState.ValidationFailed,
                AuditState.IndexingFailed
            };

            var result = _config.StatesForElmah;
            Assert.That(result, Is.EqualTo(expect));
        }

        [Test]
        public void t05_log_every_state_to_db()
        {
            SetKeyValue("LogEveryStateToDb", true);

            var expect = new List<AuditState>
            {
                AuditState.Unknown,
                AuditState.Creating,
                AuditState.Updateing,
                AuditState.Validated,
                AuditState.SavedToDb,
                AuditState.Indexed,
                AuditState.Deleting,
                AuditState.ValidationFailed,
                AuditState.DbError,
                AuditState.IndexingFailed
            };

            var result = _config.StatesForDbAudit;
            Assert.That(result.Count(), Is.EqualTo(expect.Count()));
        }

        
    }
}

