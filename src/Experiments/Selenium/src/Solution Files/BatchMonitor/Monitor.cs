using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace BatchMonitor
{
    public class Monitor
    {
        private FileSystemWatcher watcher;
        private Dictionary<string, DateTime> seen;
        private TimeSpan seenInterval;
        private Options opt;
        
        public Monitor(Options options)
        {
            opt = options;
            seen = new Dictionary<string, DateTime>();
            seenInterval = new TimeSpan(0,0, opt.PoolingInterval);

            watcher = new FileSystemWatcher(opt.MonitorDirPath, opt.TriggerName);
            watcher.IncludeSubdirectories = true;
            watcher.Created += (s, e) =>
            {
                if (!seen.ContainsKey(e.FullPath)
                    || (DateTime.Now - seen[e.FullPath]) > seenInterval)
                {
                    seen[e.FullPath] = DateTime.Now;
                    ThreadPool.QueueUserWorkItem(
                        WaitForCreatingProcessToCloseFileThenDoStuff, e.FullPath);
                }
            };
            watcher.EnableRaisingEvents = true;
        }

        private void WaitForCreatingProcessToCloseFileThenDoStuff(object threadContext)
        {
            // Make sure the just-found file is done being
            // written by repeatedly attempting to open it
            // for exclusive access.
            var path = (string)threadContext;
            DateTime started = DateTime.Now;
            DateTime lastLengthChange = DateTime.Now;
            long lastLength = 0;
            var noGrowthLimit = new TimeSpan(0, 1, 0);
            var notFoundLimit = new TimeSpan(0, 0, 1);

            for (int tries = 0;; ++tries)
            {
                try
                {
                    bool isAvailable = false;
                    using (var fs = new FileStream(
                        path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
                        isAvailable = true;
                    }
                    if (isAvailable)
                        Execute(path);
                    

                    break;
                }
                catch (FileNotFoundException)
                {
                    // Sometimes the file appears before it is there.
                    if (DateTime.Now - started > notFoundLimit)
                    {
                        // Should be there by now
                        break;
                    }
                }
                catch (IOException ex)
                {
                    // mask in severity, customer, and code
                    var hr = (int)(ex.HResult & 0xA000FFFF);
                    if (hr != 0x80000020 && hr != 0x80000021)
                    {
                        // not a share violation or a lock violation
                        throw;
                    }
                }

                try
                {
                    var fi = new FileInfo(path);
                    if (fi.Length > lastLength)
                    {
                        lastLength = fi.Length;
                        lastLengthChange = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                }

                // still locked
                if (DateTime.Now - lastLengthChange > noGrowthLimit)
                {
                    // 5 minutes, still locked, no growth.
                    break;
                }

                Thread.Sleep(111);
            }
        }

        private void Execute(string path)
        {
            //System.Diagnostics.Process.Start(path);
            //ExecuteCommand(path);
            ProcessStartInfo processInfo;
            Process process;
            string dir = Path.GetDirectoryName(path);
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + path + " " + dir);
            processInfo.CreateNoWindow = false;
            processInfo.UseShellExecute = true;
            // *** Redirect the output ***
            //processInfo.RedirectStandardError = true;
            //processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();
        }

        void ExecuteCommand(string command)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            string dir = Path.GetDirectoryName(command);
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command + " " + dir);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close();
        }
    }
}