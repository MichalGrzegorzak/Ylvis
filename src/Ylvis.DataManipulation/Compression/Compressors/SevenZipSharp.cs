using System;
using System.IO;
using System.Reflection;
using SevenZip;

namespace Ylvis.DataManipulation.Compression.Compressors
{
    class SevenZip
    {
        public static void Setup7zip()
        {
            // Toggle between the x86 and x64 bit dll
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Environment.Is64BitProcess ? "x64" : "x86", "7z.dll");
            SevenZipBase.SetLibraryPath(path);
        }

        public static void ZipFiles(string archivePath, params string[] targetFilesPath)
        {
            var compressor = new SevenZipCompressor();
            compressor.ArchiveFormat = OutArchiveFormat.SevenZip;
            compressor.CompressionMode = CompressionMode.Create;
            compressor.TempFolderPath = System.IO.Path.GetTempPath();
            //compressor.CompressDirectory(source, output);
            compressor.CompressFiles(archivePath, targetFilesPath);
        }

        public static void ZipFolder(string archivePath, string targetDir)
        {
            var compressor = new SevenZipCompressor();
            compressor.ArchiveFormat = OutArchiveFormat.SevenZip;
            compressor.CompressionMode = CompressionMode.Create;
            compressor.TempFolderPath = System.IO.Path.GetTempPath();
            compressor.CompressDirectory(targetDir, archivePath);
        }
    }
}
