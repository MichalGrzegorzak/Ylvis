using System;
using System.Collections.Generic;

namespace UrlExtractor.Tests
{
    public class ClipboardPost
    {
        public int ID { get; set; }
        public DateTime Created { get; set; }

        public string UrlFrom { get; set; }
        public string Text { get; set; }
        public string Pass { get; set; }
        public string DlKey { get; set; }
        
        public List<string> Downloads { get; set; }
        //public List<Items> CategorizedDownloads { get; set; }
    }
}