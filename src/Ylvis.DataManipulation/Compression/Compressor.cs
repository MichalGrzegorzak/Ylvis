using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using SevenZip;
using Ylvis.DataManipulation.Compression.Compressors;
using Ylvis.Extensions.Extensions;

namespace Ylvis.DataManipulation.Compression
{
    public class Compressor
    {
        //private string outputPath = null;
        private int compressorLevel = 9;
        private CompressMethod method = CompressMethod.Zip;
        private TimeSpan totalTimeSpan = new TimeSpan();

        public Compressor(CompressMethod method = CompressMethod.Zip, int level = 9)
        {
            this.method = method;
            this.compressorLevel = level;
        }

        //TODO
        //add CompressDirectory

        public string CompressFiles(string outputPath, params string[] targetFiles)
        {
            Stopwatch st = new Stopwatch();
            st.Start();

            ChooseCompression(outputPath, targetFiles);

            st.Stop();
            totalTimeSpan = totalTimeSpan.Add(st.Elapsed);

            return "Finished " + method + " in " + st.Elapsed.ElapsedToString();
        }

        public string GetTotalCompressorTime()
        {
            return totalTimeSpan.ElapsedToString();
        }

        private void ChooseCompression(string outputPath, params string[] targetFiles)
        {
            //if ext. missing will add it here
            outputPath = AddExtensionIfMissing(outputPath, method);

            switch (method)
            {
                case CompressMethod.SevenZip:
                    Compressors.SevenZip.Setup7zip();
                    Compressors.SevenZip.ZipFiles(outputPath, targetFiles);
                    break;
                default:
                    SharpZipLib.ZipFiles(outputPath, targetFiles);
                    break;
            }
        }

        private static string AddExtensionIfMissing(string outputPath, CompressMethod method)
        {
            if (!outputPath.Contains(".zip") && !outputPath.Contains(".7z"))
            {
                switch (method)
                {
                    case CompressMethod.SevenZip: return outputPath += ".7z";
                    case CompressMethod.Zip: return outputPath += ".zip";
                }
            }
            return outputPath;
        }
    }
}