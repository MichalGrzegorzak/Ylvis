using System.Collections.Generic;
using PropertyChanged;
using UrlExtractor.Model;

namespace UrlExtractor.Wpf.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class ClipboardVm
    {
        public ClipboardVm()
        {
            ClipboardPost post = new ClipboardPost()
            {
                Pass = "unknown",
                DlKey = "unknown",
                FromUrl = "unknown",
                Text = "unknown"
            };
            post.Downloads.Add("empty");
            Init(post);
        }
        public ClipboardVm(ClipboardPost post)
        {
            Init(post);
        }

        private void Init(ClipboardPost post)
        {
            Url = post.FromUrl;
            Pass = post.Pass;
            DlKey = post.DlKey;
            //Downloads = string.Join("\r\n", post.Downloads);
            Downloads = post.Downloads;
            Previews = post.Previews;
            Mirrors = post.Mirrors;
            Created = post.Created.ToShortDateString();
            Id = post.Id;
        }
        public void UpdateModel(ClipboardPost post)
        {
            post.FromUrl = Url;
            post.Pass = Pass;
            post.DlKey = DlKey;
            post.Downloads = Downloads;
            post.Previews = Previews;
            post.Mirrors = Mirrors;
            //post.Created.ToShortDateString() = Created;
            //post.Id = Id;
        }

        public string Url { get; set; }
        //public string Text { get; set; }

        public int Count => Downloads.Count;

        public string Pass { get; set; }
        public string DlKey { get; set; }
        public string Created { get; set; }
        public int Id { get; set; }

        public List<string> Downloads { get; set; } = new List<string>();
        public List<string> Mirrors { get; set; } = new List<string>();
        public List<string> Previews { get; set; } = new List<string>();

        //public string Downloads { get; set; }
        //public string Previews { get; set; }
        //public List<Items> CategorizedDownloads { get; set; }
    }
}