using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UrlExtractor.Model
{
    public class LinkFilter
    {
        public bool FilterLocal { get; set; } = true;
        public bool OnlyOnion { get; set; } = true;

        public LinkGrouper FilterLinks(IEnumerable<string> allLinks)
        {
            LinkGrouper grouper = new LinkGrouper();
            foreach (string link in allLinks)
            {
                if (FilterLocal)
                {
                    if(!link.StartsWith("http"))
                        continue;
                }
                if (OnlyOnion)
                {
                    if (!link.Contains(".onion"))
                        continue;
                }
                grouper.AddLink(link);

            }
            return grouper;
        }
    }

    public enum DownloadItemType
    {
        nn = 0,
        download = 1,
        mirror = 2
    }

    public class DownloadItem
    {
        public string Download { get; set; }
        public string Preview { get; set; }
        public string Type { get; set; }
    }

    public class ItemAnalyzer
    {
        private string _rawTest;

        public List<string> FilteredOutput { get; set; } = new List<string>();

        public List<string> AllLinks { get; set; } = new List<string>();
        public List<DownloadItem> AllLinksItems { get; set; } = new List<DownloadItem>();

        public List<string> Previews { get; set; } = new List<string>();
        public List<string> Parts { get; set; } = new List<string>();
        public List<string> Mirrors { get; set; } = new List<string>();
        public List<string> Downloads { get; set; } = new List<string>();
        public List<string> Passwords { get; set; } = new List<string>();
        public List<string> DLKeys { get; set; } = new List<string>();

        const string LINK = @"(www.+|http.+)([\s]|$)";
        const string IS = @"[:|=]?\s*";
        Regex regAllLinks = new Regex(LINK, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        Regex regSingleLink = new Regex(LINK, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

        Regex regPartWords = new Regex($@"(part[s]?)\s*(\d)?{IS}{LINK}", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
        Regex regBackups = new Regex($@"(backup|mir[r]?or[s]?|back)\s*([0-9]*){IS}{LINK}", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
        Regex regLinkWords = new Regex(@"(link[s]?)\s*(\d)?", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
        Regex regPreviewss = new Regex($@"(preview[s]|image|gallery)\s*(\d)?{LINK}", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

        Regex regPassword = new Regex(@"(passwor[d|t]|pass|)\s*([:|=]?\s+)(.+)", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
        Regex regDlKey = new Regex(@"(key)\s*(\d)?", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

        public bool HasParts => Parts.Any();
        public bool HasLinks => Downloads.Any();
        public bool HasPreview => Previews.Any();
        public bool HasPass => Passwords.Any();
        public bool HasDLKey => DLKeys.Any();
        public bool HasMirrors => Mirrors.Any();

        public ItemAnalyzer(string rawText)
        {
            _rawTest = rawText;

            //store all links
            MatchCollection ms = regAllLinks.Matches(_rawTest);
            foreach (Match match in ms)
            {
                AllLinks.Add(match.Value);
            }

            //if (_rawTest.Contains("part"))
            //    HasParts = true;
            //if (_rawTest.Contains("link"))
            //    HasLinks = true;
            //if (_rawTest.Contains("preview"))
            //    HasPreview = true;
            //if (_rawTest.Contains("pass"))
            //    HasPass = true;
            //if (_rawTest.Contains("key"))
            //    HasDLKey = true;
        }

        public void Analyze()
        {
            int partIndex = 0;

            var allLines = _rawTest.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < allLines.Length; i++)
            {
                string line = allLines[i].Trim();
                string nextLine = string.Empty;
                if(i < allLines.Length - 1)
                    nextLine = allLines[i+1].Trim();

                if (line.ToLowerInvariant().Contains("pass"))
                {
                    var matchPart = regPassword.Matches(line);
                    if (matchPart.Count > 0 && matchPart[0].Success)
                    {
                        string pass = matchPart[0].Groups[3].Value;
                        Passwords.Add(pass);
                        FilteredOutput.Add(pass);
                        continue;
                    }
                    else
                    {
                        Passwords.Add(nextLine);
                        FilteredOutput.Add(nextLine);
                        i++;
                        //matchPart = regPartWords.Matches(nextLine);
                        //if (matchPart.Count > 0 && matchPart[0].Success)
                        //{
                        //    i++;
                        //    string pass = matchPart[0].Groups[1].Value;
                        //    Passwords.Add(pass);
                        //}
                    }
                }

                if (line.ToLowerInvariant().Contains("part"))
                {
                    var matchPart = regPartWords.Matches(line);
                    if (matchPart.Count > 0  && matchPart[0].Groups.Count == 5)
                    {
                        string index = matchPart[0].Groups[2].Value;
                        string link = matchPart[0].Groups[3].Value;
                        FilteredOutput.Add(line);
                        Parts.Add($"PART:{index} -> link");
                    }
                    else
                    {
                        var linkMatch = regSingleLink.Match(line);
                        if (linkMatch.Success)
                        {
                            Parts.Add(linkMatch.Value);
                            FilteredOutput.Add(line);
                            partIndex++;
                        }
                        else
                        {
                            linkMatch = regSingleLink.Match(nextLine);
                            if (linkMatch.Success)
                            {
                                Parts.Add(linkMatch.Value);
                                partIndex++;
                                FilteredOutput.Add($"PART {partIndex}: {linkMatch.Value}");
                                i++;
                            }
                        }

                        
                    }
                    continue;
                }

                if (line.ToLowerInvariant().Contains("link"))
                {
                    //var matchPart = regLinkWords.Matches(line)[0];
                    //if (matchPart.Success && matchPart.Captures.Count == 2)
                    //{
                    //    int end = matchPart.Groups.Count - 1;
                    //    string index = matchPart.Groups[end].Value;
                    //}

                    var linkMatch = regSingleLink.Match(line);
                    if (linkMatch.Success)
                    {
                        Downloads.Add(linkMatch.Value);
                        FilteredOutput.Add(line);
                    }
                    else
                    {
                        linkMatch = regSingleLink.Match(nextLine);
                        if (linkMatch.Success)
                        {
                            Downloads.Add(linkMatch.Value);
                            i++;
                            FilteredOutput.Add("LINK:" + linkMatch.Value);
                        }
                    }
                    continue;
                }
            }
        }

        public List<string> ControlWords { get; set; } = new List<string>(new string []
        {
            "Link", "Backup", "Preview",
            "Password", "Pass", "Passwort",
            "DL Key", "Key", "DLKey"
        });
    }
}