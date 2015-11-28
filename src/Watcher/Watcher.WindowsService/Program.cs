using System.ServiceProcess;

namespace Watcher.WindowsService
{
    static class Program
    {
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new DirectoryMonitoringService() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
