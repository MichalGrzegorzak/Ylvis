using Watcher.Core.Settings;
using Watcher.WindowsService;
using Ylvis.Utils.Helpers;

namespace Watcher.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToFolder = AppSettings.Inst.MonitorFolder;
            SimpleLog.Instance.LogPath = AppSettings.Inst.LogsFolder;
            SimpleLog.Instance.LogFileName = AppSettings.Inst.LogFileName;

            var watcher = new MyFileSystemWatcher(pathToFolder);

            System.Console.WriteLine("Press any key to quit");
            System.Console.ReadLine();
        }
    }
}
