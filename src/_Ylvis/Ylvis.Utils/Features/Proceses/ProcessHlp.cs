using System.Diagnostics;

namespace Ylvis.Utils.Features.Proceses
{
    public abstract class ProcessHlp
    {
        public static bool StartProgram(string location, string args, Process proc = null, bool createWindow = true)
        {
            proc = proc ?? new Process();
            proc.StartInfo.FileName = location;
            proc.StartInfo.Arguments = args;
            proc.StartInfo.CreateNoWindow = !createWindow;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            return proc.Start();
        }

        public static bool StartAndKillProgram(string location, string args)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = location;
            startInfo.Arguments = args;
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process proc = Process.Start(startInfo);
            proc.WaitForExit(10000); // Wait a maximum of 10 sec for the process to finish
            if (!proc.HasExited)
            {
                proc.Kill();
                proc.Dispose();
                return false;
            }
            return true;
        }

        //public static bool OpenPdfWithFoxit(string pdfPath, Process proc = null)
        //{
        //    string args = @" {0}".Frmt(pdfPath);
        //    string location = Const.FoxitPath; //uwaga na nazwe pliku - raz ze spacja raz bez
        //    return ProcessHlp.StartProgram(location, args);
        //}
    }
}
