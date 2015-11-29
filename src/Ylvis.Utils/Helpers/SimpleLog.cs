using System;
using System.IO;

namespace Ylvis.Utils.Helpers
{
    public class SimpleLog
    {
        public static SimpleLog Instance = new SimpleLog();

        private SimpleLog()
        {
            LogFileName = "Example";
            LogFileExtension = ".log";
        }
        static SimpleLog()
        {
        }

        protected StreamWriter Writer { get; set; }

        public string LogPath { get; set; }

        public string LogFileName { get; set; }

        public string LogFileExtension { get; set; }

        public string LogFile { get { return LogFileName + LogFileExtension; } }

        public string LogFullPath { get { return Path.Combine(LogPath, LogFile); } }

        public bool LogExists { get { return File.Exists(LogFullPath); } }

        public void WriteLineToLog(String inLogMessage)
        {
            WriteToLog(inLogMessage + Environment.NewLine);
        }

        public void WriteToLog(String inLogMessage)
        {
            if (!Directory.Exists(LogPath))
            {
                Directory.CreateDirectory(LogPath);
            }
            if (Writer == null)
            {
                Writer = new StreamWriter(LogFullPath, true);
            }

            Writer.Write(inLogMessage);
            Writer.Flush();
        }

        public static void WriteLine(String inLogMessage)
        {
            SimpleLog.Instance.WriteLineToLog(inLogMessage);
            Console.WriteLine(inLogMessage);
        }

        public static void Write(String inLogMessage)
        {
            SimpleLog.Instance.WriteToLog(inLogMessage);
            Console.Write(inLogMessage);
        }
    }
}
