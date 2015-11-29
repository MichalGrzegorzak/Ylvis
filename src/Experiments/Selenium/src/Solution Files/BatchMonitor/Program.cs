using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BatchMonitor
{
    internal class Program
    {
        private static Monitor mon;

        private static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                // consume values here
                // Values are available here
                if (!string.IsNullOrEmpty(options.MonitorDirPath))
                    Console.WriteLine("MonitorDirPath: {0}", options.MonitorDirPath);

                mon = new Monitor(options);
                while (true)
                {
                    Thread.Sleep(1000 * 1);
                }
                Console.ReadKey();
            }
        }
    }
}