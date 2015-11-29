using System.Collections.Generic;
using System.IO;

namespace elvSplitter
{
    public class FileCreator
    {
        private string dirPath;
        private List<TargetInfo> allTargets;
        private StreamWriter writer;
        private FileCreatorSettings settings;

        public FileCreator(string dirPath, FileCreatorSettings settings)
        {
            this.dirPath = dirPath;
            this.settings = settings;
        }
        
        public void CreateAFile(List<TargetInfo> allTargets)
        {
            this.allTargets = allTargets;

            using (writer = File.CreateText(dirPath + "/" + settings.FileName))
            {
                WriteHeader(); //define path & vars

                WriteCompressionLines();
                RemoveCompressedFolders();

                WriteFooter(); //cleanup
            }
        }

        private void WriteHeader()
        {
            string header1 = @"SET zip=""{SevenZipPath}"" ";
            string header2 = @"SET level=" + settings.CompressionLevel;
            string header3 = @"SET archiveSize=" + settings.ArchiveSize;

            writer.WriteLine(header1.Frmt(settings));
            writer.WriteLine(header2);
            writer.WriteLine(header3);
            writer.WriteLine("");
        }

        private void WriteFooter()
        {
            const string footer1 = @"del elvSplitter.exe /Q";
            const string footer2 = @"del {FileName} /Q";
            const string footer3 = @"pause";
            writer.WriteLine(footer1);
            writer.WriteLine(footer2.Frmt(settings));
            writer.WriteLine(footer3);
        }

        private void WriteCompressionLines()
        {
            const string lineCompressAndSplit = @"%zip% a ""{name}.7z"" -mx{lvl} -v{archiveSize}m ""{name}"" ";
            const string lineCompress = @"%zip% a ""{name}.7z"" -mx{lvl} ""{name}"" ";

            foreach (TargetInfo target in allTargets)
            {
                string result = "";
                object formatter = new {name = target.Name, lvl = settings.CompressionLevel, archiveSize = settings.ArchiveSize};
                
                if (target.Size > settings.ArchiveSize)
                    result = lineCompressAndSplit.Frmt(formatter);
                else
                    result = lineCompress.Frmt(formatter);

                writer.WriteLine(result);
            }
            writer.WriteLine("");
        }

        private void RemoveCompressedFolders()
        {
            const string delete = @"del ""{Name}"" /Q";
            const string deleteDir = @"RMDIR ""{Name}"" /S /Q";

            foreach (TargetInfo target in allTargets)
            {
                writer.WriteLine(delete.Frmt(target));
                if (target.IsDir)
                {
                    writer.WriteLine(deleteDir.Frmt(target));
                }
            }
            writer.WriteLine("");
        }
    }
}