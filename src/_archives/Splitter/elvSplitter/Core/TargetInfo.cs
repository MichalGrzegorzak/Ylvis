namespace elvSplitter
{
    public class TargetInfo
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }
        public bool IsDir { get; set; }

        public TargetInfo(string name, long size, bool isDir = false, string ext = "")
        {
            Name = name;
            Size = (int)(size / (1024 * 1024) );
            IsDir = isDir;
            Extension = ext;
        }
    }
}