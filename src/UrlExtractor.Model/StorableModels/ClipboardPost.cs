using System;
using System.Collections.Generic;

namespace UrlExtractor.Model
{
    public class ClipboardPost : BaseID
    {
        public string FromUrl { get; set; }
        public string Text { get; set; }

        public string Pass { get; set; }
        public string DlKey { get; set; }
        
        public List<string> Downloads { get; set; }
        //public List<Items> CategorizedDownloads { get; set; }
    }
}