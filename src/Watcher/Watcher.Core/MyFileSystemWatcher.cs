using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using Ylvis.DataManipulation.Compression;
using Ylvis.DataManipulation.Compression.Compressors;
using Ylvis.Extensions;

namespace Watcher.WindowsService
{
    public class MyFileSystemWatcher : FileSystemWatcher
    {
        static ConcurrentDictionary<string, FileSystemEventArgs> fileList = new ConcurrentDictionary<string, FileSystemEventArgs>();
        static BackgroundWorker worker = new BackgroundWorker();


        public MyFileSystemWatcher(string inDirectoryPath)
            : base(inDirectoryPath)
        {
            Init(inDirectoryPath);
        }

        public MyFileSystemWatcher(string inDirectoryPath, string inFilter)
            : base(inDirectoryPath, inFilter)
        {
            Init(inDirectoryPath);
        }

        private void Init(string inDirectoryPath)
        {
            IncludeSubdirectories = true;
            // Eliminate duplicates when timestamp doesn't change
            //NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size; // The default also has NotifyFilters.LastWrite
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.LastWrite;
            EnableRaisingEvents = true;
            //Created += Watcher_Created;
            Changed += Watcher_Changed;
            Deleted += Watcher_Deleted;
            //Renamed += Watcher_Renamed;

            var files = Directory.GetFiles(inDirectoryPath);
            foreach (string file in files)
            {
                string fileName = new FileInfo(file).Name;
                var arg = new FileSystemEventArgs(WatcherChangeTypes.All, inDirectoryPath, fileName);
                fileList[fileName] = arg;
            }

            
            
            BackgroundWorkerRun();
        }

        private void BackgroundWorkerRun()
        {
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            //This must be set to true in order to be able to cancel the worker
            worker.WorkerSupportsCancellation = true;
            //This must be set to true in order to report progress
            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync();
        }

        static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SimpleLog.Write("Job completed");
        }

        static void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SimpleLog.Write(e.UserState.ToString());
        }

        static void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var copy = new List<FileSystemEventArgs>(fileList.Values.ToList());
            foreach (FileSystemEventArgs s in copy)
            {
                SimpleLog.WriteLine("Found: " + s.Name);
            }

            int sum = copy.Count;
            int i = 1;
            foreach (FileSystemEventArgs s in copy)
            {
                if (IsFileLocked(s.FullPath))
                    continue;

                FileSystemEventArgs x = null;
                if (!worker.CancellationPending)
                {
                    ZipFile(s);
                    worker.ReportProgress(1, i + " of " + sum);
                    fileList.TryRemove(s.Name, out x);
                    i++;
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
                
            }

            Thread.Sleep(5 * 1000);
            worker_DoWork(null, e);
        }

        private static void ZipFile(FileSystemEventArgs inArgs)
        {
            string name = inArgs.Name.Substring(0, inArgs.Name.LastIndexOf('.'));
            SimpleLog.WriteLine("Zipping: " + name);

            string targetPath = inArgs.FullPath;
            string outputPath = @"D:\compressed\" + name;

            var zipCompressor = new Compressor(outputPath + ".zip", CompressMethod.Zip);
            var sevenZipCompressor = new Compressor(outputPath + ".7z", CompressMethod.SevenZip);
            SimpleLog.WriteLine(zipCompressor.CompressFiles(targetPath));
            SimpleLog.WriteLine(sevenZipCompressor.CompressFiles(targetPath));
        }

        public void Watcher_Created(object source, FileSystemEventArgs inArgs)
        {
            SimpleLog.WriteLine("File created or added: " + inArgs.FullPath);
            
            fileList[inArgs.Name] = inArgs;
        }

        public void Watcher_Changed(object sender, FileSystemEventArgs inArgs)
        {
            fileList[inArgs.Name] = inArgs;
            SimpleLog.WriteLine("File changed added to Queue: " + inArgs.FullPath);
        }

        public void Watcher_Deleted(object sender, FileSystemEventArgs inArgs)
        {
            SimpleLog.WriteLine("File deleted: " + inArgs.FullPath);

            FileSystemEventArgs removed;
            fileList.TryRemove(inArgs.Name, out removed);
        }

        //public void Watcher_Renamed(object sender, RenamedEventArgs inArgs)
        //{
        //    Log.WriteLine("File renamed: " + inArgs.OldFullPath + ", New name: " + inArgs.FullPath);
        //    fileList.Remove(inArgs.OldFullPath);
        //    fileList.Add(inArgs.FullPath);
        //}

        public static bool IsFileLocked(string fullPath)
        {
            FileInfo fInfo = new FileInfo(fullPath); 

            FileStream stream = null;
            try
            {
                stream = fInfo.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

        

        
    }
}
