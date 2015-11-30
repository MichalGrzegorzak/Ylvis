using System;
using System.Collections.Generic;
using System.Text;
using SevenZip;

namespace SVNKiller
{
    public class ZipHelper
    {
        private string _targetPath = "";

        public ZipHelper(string targetPath)
        {
            _targetPath = targetPath;    
        }
        
        public void Pack(string outputPath)
        {
            SevenZipCompressor tmp = new SevenZipCompressor();
            tmp.FileCompressionStarted += new EventHandler<FileInfoEventArgs>((s, e) => 
            {
                Console.WriteLine(String.Format("[{0}%] {1}",
                    e.PercentDone, e.FileInfo.Name));
            });
            tmp.CompressDirectory(_targetPath, outputPath, OutArchiveFormat.SevenZip);
        }

        public void Unpack(string outputPath)
        {
            SevenZipExtractor tmp = new SevenZipExtractor(_targetPath);
            tmp.FileExtractionStarted += new EventHandler<IndexEventArgs>((s, e) =>
            {
                Console.WriteLine(String.Format("[{0}%] {1}", 
                    e.PercentDone, tmp.ArchiveFileData[e.FileIndex].FileName));
            });
            tmp.ExtractionFinished += new EventHandler((s, e) => {Console.WriteLine("Finished!");});
            tmp.ExtractArchive(outputPath);
        }
    }
}
