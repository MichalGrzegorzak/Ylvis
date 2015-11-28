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
using Ylvis.Extensions.Helpers;

namespace Watcher.WindowsService
{
    public class MyFileSystemWatcher : FileSystemWatcher
    {
        static ConcurrentDictionary<string, FileSystemEventArgs> fileList = new ConcurrentDictionary<string, FileSystemEventArgs>();
        static BackgroundWorker worker = new BackgroundWorker();
        static Compressor zipCompressor = new Compressor(CompressMethod.Zip);
        static Compressor sevenZipCompressor = new Compressor(CompressMethod.SevenZip);

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
            Changed += Watcher_Changed;
            Deleted += Watcher_Deleted;
            //Created += Watcher_Created;
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
            //This must be set to true in order to be able to cancel the worker
            worker.WorkerSupportsCancellation = true;
            //This must be set to true in order to report progress
            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync();
            //worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        //static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    SimpleLog.Write("Job completed");
        //}

        static void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SimpleLog.WriteLine(e.UserState.ToString());
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
                if (FileHlp.IsFileLocked(s.FullPath))
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

            if (copy.Any())
            {
                SimpleLog.WriteLine("7zip total time : " + sevenZipCompressor.GetTotalCompressorTime());
                SimpleLog.WriteLine("Zip total time : " + zipCompressor.GetTotalCompressorTime());
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

            
            SimpleLog.WriteLine(zipCompressor.CompressFiles(outputPath + ".zip", targetPath));
            SimpleLog.WriteLine(sevenZipCompressor.CompressFiles(outputPath + ".7z", targetPath));
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
    }
}
