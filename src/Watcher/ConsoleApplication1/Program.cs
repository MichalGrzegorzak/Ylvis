using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectoryMonitoring;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string PathToFolder = @"d:\dirMonitor\";

            SimpleLog.Instance.LogPath = @"d:\";
            SimpleLog.Instance.LogFileName = "dirMonitoring.log";
            var watcher = new MyFileSystemWatcher(PathToFolder);

            Console.ReadLine();
        }
    }
}
