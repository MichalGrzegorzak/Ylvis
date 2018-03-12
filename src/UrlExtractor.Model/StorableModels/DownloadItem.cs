using System.Collections.Generic;

namespace UrlExtractor.Model
{
    public class DownloadItem : BaseID
    {
        public int Index { get; set; }
        public string Description { get; set; }

        public string Download { get; set; }
        public string Preview { get; set; }
        public DownloadItemType Type { get; set; }

        public List<string> Mirrors { get; set; }
    }

    public class BaseID
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
    }
}