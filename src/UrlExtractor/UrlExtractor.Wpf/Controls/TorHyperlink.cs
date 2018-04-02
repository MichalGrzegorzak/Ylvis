using System.Diagnostics;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace UrlExtractor.Wpf.Controls
{
    public class TorHyperlink : Hyperlink
    {
        string browser = @"C:\Users\user\Desktop\TBrowser\Browser\firefox.exe";
        //private string browser = @"C:\Program Files(x86)\Mozilla Firefox\firefox.exe";
        public TorHyperlink()
        {
            RequestNavigate += OnRequestNavigate;
        }

        private void OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            //a = Environment.ExpandEnvironmentVariables(a);
            //https://check.torproject.org/?lang=en_US
            Process.Start(new ProcessStartInfo()
            {
                FileName = browser, //"firefox.exe",  
                Arguments = $"--allow-remote -new-tab {e.Uri.AbsoluteUri}"
            });
            e.Handled = true;
        }

    }
}