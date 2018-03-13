using System;
using System.Collections.Generic;
using System.Linq;

namespace UrlExtractor.Model
{
    public class ClipboardPost : BaseID
    {
        public string FromUrl { get; set; }
        public string Text { get; set; }
        public string RawText { get; set; }

        public string Pass { get; set; }
        public string DlKey { get; set; }
        
        public List<string> Downloads { get; set; } = new List<string>();
        public List<string> Previews { get; set; } = new List<string>();
        //public List<Items> CategorizedDownloads { get; set; }
    }

    public abstract class PostFactory
    {
        public static ClipboardPost CreatePost(string rawText, string url)
        {
            ClipboardPost post = new ClipboardPost() {RawText = rawText, FromUrl = url};

            ItemAnalyzer analyzer = new ItemAnalyzer(rawText);
            analyzer.Analyze();

            post.Pass = analyzer.Passwords.FirstOrDefault();
            post.DlKey = analyzer.DLKeys.FirstOrDefault();
            post.Text = String.Join("\r\n", analyzer.FilteredOutput);
            post.Previews = analyzer.Previews;
            //
            post.Downloads.AddRange(analyzer.Parts);
            post.Downloads.AddRange(analyzer.Downloads);
            post.Downloads.AddRange(analyzer.Mirrors);

            return post;
        }

        public static string Test1()
        {
            return @"
            Last update: 12.11.2018
            Preview: Image

                Backup Preview: http://twlba5.com/?img=351.jpg

            Part 1: https://minfil.org/veD20/usn.rar

            Part 2: http://dl.free.fr/mrO3

            Backup Link: http://upfile.mobi/toi8C

            Link: http://addfile.org/3pSX

            Link: http://qtfile.com/lOev

            Link: http://9files.co/KHr

            Password: =)(§$$Z /%)(ßihs
            ";
        }
    }
}