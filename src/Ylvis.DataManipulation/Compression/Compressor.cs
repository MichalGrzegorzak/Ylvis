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
        private string outputPath = null;
        private int compressorLevel = 9;
        private CompressMethod method = CompressMethod.Zip;
        private TimeSpan totalTimeSpan = new TimeSpan();

        public Compressor(string outputPath, CompressMethod method = CompressMethod.Zip, int level = 9)
        {
            this.method = method;
            this.compressorLevel = level;
            this.outputPath = AddExtensionIfMissing(outputPath, method);
        }

        //TODO
        //add CompressDirectory

        public string CompressFiles(params string[] targetFiles)
        {
            Stopwatch st = new Stopwatch();
            st.Start();

            ChooseCompression(targetFiles);

            st.Stop();
            totalTimeSpan.Add(st.Elapsed);

            return "Finished " + method + " in " + st.Elapsed.ElapsedToString();
            //var seconds = st.Elapsed.TotalSeconds;
            //if (seconds > 100)
            //    return header + st.Elapsed.TotalMinutes.Round() + " min";
            //else if(seconds > 10)
            //    return header + st.Elapsed.TotalSeconds.Round() + " sec";
            //else
            //    return header + st.Elapsed.TotalMilliseconds.Round() + " milisec";
        }

        private void ChooseCompression(params string[] targetFiles)
        {
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