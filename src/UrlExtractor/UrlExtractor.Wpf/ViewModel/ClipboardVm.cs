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
            Downloads = string.Join("\r\n", post.Downloads);
        }

        public string Url { get; set; }
        //public string Text { get; set; }

        public string Pass { get; set; }
        public string DlKey { get; set; }

        public string Downloads { get; set; }
        public string Previews { get; set; }
        //public List<Items> CategorizedDownloads { get; set; }
    }
}