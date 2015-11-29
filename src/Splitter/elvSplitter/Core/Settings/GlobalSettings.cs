namespace elvSplitter
{
    public class LocatorSettings
    {
        public LocatorSettings()
        {
            MinDirSize = 10;
            MinFileSize = 800;
            ExcludeExtension = new string[] { ".exe", ".bat", ".7z", ".001" };
        }
        
        public int MinDirSize { get; set; }
        public int MinFileSize { get; set; }
        public string[] ExcludeExtension { get; set; } 
    }

    /// <summary>
    /// http://www.dotnetperls.com/7-zip-examples
    /// </summary>
    public class FileCreatorSettings
    {
        public FileCreatorSettings()
        {
            FileName = "splitter.bat";
            CompressionLevel = 5; //0 - no / 3 fast / 5 normal / 7 maximum
            ArchiveSize = 800;
            SevenZipPath = @"c:\tools\7za.exe";
        }
        
        public string FileName { get; set; }
        public string SevenZipPath { get; set; }
        public int CompressionLevel { get; set; }
        public int ArchiveSize { get; set; }
    }
}