using System.IO;
using System.ServiceProcess;
using Ylvis.Extensions;

namespace Watcher.WindowsService
{
    public partial class DirectoryMonitoringService : ServiceBase
    {
        protected FileSystemWatcher Watcher;

        // Directory must already exist unless you want to add your own code to create it.
        string PathToFolder = @"d:\dirMonitor\";

        public DirectoryMonitoringService()
        {
            SimpleLog.Instance.LogPath = @"d:\";
            SimpleLog.Instance.LogFileName = "dirMonitoring.log";
            Watcher = new MyFileSystemWatcher(PathToFolder);
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
