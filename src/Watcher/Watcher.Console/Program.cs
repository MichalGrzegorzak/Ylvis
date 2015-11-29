using Watcher.WindowsService;
using Ylvis.Utils.Helpers;

namespace Watcher.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string PathToFolder = @"d:\dirMonitor\";

            SimpleLog.Instance.LogPath = @"d:\";
            SimpleLog.Instance.LogFileName = "dirMonitoring.log";
            var watcher = new MyFileSystemWatcher(PathToFolder);

            System.Console.ReadLine();
        }
    }
}
