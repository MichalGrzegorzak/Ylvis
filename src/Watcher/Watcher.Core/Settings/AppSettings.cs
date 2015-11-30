using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ylvis.Utils.Extensions;
using Ylvis.Utils.Features.AppSettings;

namespace Watcher.Core.Settings
{
    [Serializable]
    public class AppSettings : ConfigurationBase<AppSettings>
    {
        public bool IsDevMode { get; set; }
        public bool DeleteCompressedFiles { get; set; }
        //public bool KeepDefinedStructure { get; set; }
        public bool MonitorSubdirectories { get; set; }
        //
        public string MonitorFolder { get; set; }
        public string OutputFolder { get; set; }
        public string LogsFolder { get; set; }
        public string LogFileName { get; set; }

        public override void Initialize(IConfigurationManager configuration)
        {
            Configuration = configuration;
            //
            IsDevMode = ReadAppSettingsEntry<bool>("IsDevMode", true);
            DeleteCompressedFiles = ReadAppSettingsEntry<bool>("DeleteCompressedFiles", true);
            MonitorSubdirectories = ReadAppSettingsEntry<bool>("MonitorSubdirectories", false);
            //
            MonitorFolder = ReadAppSettingsEntry<string>("MonitorFolder", @"d:\dirMonitor\");
            OutputFolder = ReadAppSettingsEntry<string>("OutputFolder", @"\compressed\");
            LogsFolder = ReadAppSettingsEntry<string>("LogsFolder", @"\logs");
            LogFileName = ReadAppSettingsEntry<string>("LogFileName", "monitoring.log");

            PostInitialize();
        }

        private void PostInitialize()
        {
            Directory.CreateDirectory(OutputFolder.EnsureFullPath(MonitorFolder));
            Directory.CreateDirectory(LogsFolder.EnsureFullPath(MonitorFolder));
        }

    }
}
