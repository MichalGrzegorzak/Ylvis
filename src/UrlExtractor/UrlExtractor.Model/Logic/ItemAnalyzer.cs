using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Ylvis.Utils.Extensions;

namespace UrlExtractor.Model
{
    public class ItemAnalyzer
    {
        private string _rawTest;

        public List<string> FilteredOutput { get; set; } = new List<string>();

        public List<string> AllLinks { get; set; } = new List<string>();
        public List<DownloadItem> AllLinksItems { get; set; } = new List<DownloadItem>();

        public List<string> Previews { get; set; } = new List<string>();
        public List<string> Parts { get; set; } = new List<string>();
        public List<string> Mirrors { get; set; } = new List<string>();

        public List<string> Downloads
        {
            get
            {
                List<string> results = new List<string>(Parts);
                results.AddRange(Mirrors);
                return results;
            }
        }


        public List<string> Passwords { get; set; } = new List<string>();
        public List<string> DLKeys { get; set; } = new List<string>();

        const string LINK = @"(www.+|http.+)([\s]|$)";
        const string IS = @"[:|=]?\s*";
        Regex regAllLinks = new Regex(LINK, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        Regex regSingleLink = new Regex(LINK, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

        Regex regPartWords = new Regex($@"(part[s]?)\s*(\d)?{IS}{LINK}", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
        Regex regBackups = new Regex($@"(back[up]?|mir[r]?or[s]?)\s*([0-9]*){IS}{LINK}", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
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
            linkCounter = new Dictionary<string, int>();

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

        private bool GetPassword(string line, string nextLine, ref int i)
        {
            
            var matchPart = regPassword.Matches(line);
            if (matchPart.Count > 0 && matchPart[0].Success)
            {
                string pass = matchPart[0].Groups[3].Value;
                Passwords.Add(pass);
                FilteredOutput.Add(pass);
                return true;
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

            return false;
        }

        private Dictionary<string, int> linkCounter = null;

        private bool ExtractLinkInfoFromAnotherLine(string line, string nextLine, ref int i)
        {
            bool containsPart = line.ToLowerInvariant().Contains("part", "link");
            bool containsMirror = line.ToLowerInvariant().ContainsAnyOf("backup", "mirr");
            bool containsPreview = line.ToLowerInvariant().ContainsAnyOf("prev", "image", "gallery");
            string result = null;

            if (containsPart)
            {
                result = ExtractLink(line, nextLine, "Part", ref i, Parts);
            }

            if (containsMirror)
            {
                result = ExtractLink(line, nextLine, "Mirror", ref i, Mirrors);
            }

            if (containsPreview)
            {
                result = ExtractLink(line, nextLine, "Preview", ref i, Previews);
            }

            return (result != null);
        }

        private bool ExtractLinkInfo(string line)
        {
            bool containsPart = line.ToLowerInvariant().Contains("part", "link");
            bool containsMirror = line.ToLowerInvariant().ContainsAnyOf("backup", "mirr");
            bool containsPreview = line.ToLowerInvariant().ContainsAnyOf("prev", "image", "gallery");
            string part = string.Empty, link = string.Empty;

            if (containsPreview)
            {
                if (GetPartAndPreview(line, ref part, ref link))
                {
                    FilteredOutput.Add(line);
                    Previews.Add($"PREV {part}: {link}");
                    return true;
                }
                else //PREV without a number
                {
                    var linkMatch = regSingleLink.Match(line);
                    if (linkMatch.Success)
                    {
                        FilteredOutput.Add(line);
                        Mirrors.Add($"PREV : {linkMatch.Value}");
                        return true;
                    }
                }
            }

            if (containsPart)
            {
                if (GetPartAndLink(line, ref part, ref link))
                {
                    FilteredOutput.Add(line);
                    Parts.Add($"PART{part}: {link}");
                    return true;
                }
            }

            if (containsMirror || containsPart)
            {
                if (GetMirrorAndLink(line, ref part, ref link))
                {
                    FilteredOutput.Add(line);
                    Mirrors.Add($"MIRROR {part}: {link}");
                    return true;
                }
                else //LINK or PART without a number
                {
                    var linkMatch = regSingleLink.Match(line);
                    if (linkMatch.Success)
                    {
                        FilteredOutput.Add(line);
                        Mirrors.Add($"MIRROR : {linkMatch.Value}");
                        return true;
                    }
                }
            }

            return false;
        }

        public void AnalyzeByLine()
        {
            int partIndex = 0, prevIndex = 0;

            var allLines = _rawTest.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < allLines.Length; i++)
            {
                string line = allLines[i].Trim();
                string nextLine = string.Empty;
                if (i < allLines.Length - 1)
                    nextLine = allLines[i + 1].Trim();



                bool hasPass = line.ToLowerInvariant().Contains("pass");
                bool containsUrl = line.ToLowerInvariant().ContainsAnyOf("http", "www");

                if (!containsUrl && hasPass)
                {
                    if(GetPassword(line, nextLine, ref i))
                        continue;
                }
                //bool nextContainsUrl = nextLine.ToLowerInvariant().ContainsAnyOf("http", "www");
                //bool nextContainsPart = nextLine.ToLowerInvariant().Contains("part", "link");
                //bool nextContainsMirror = nextLine.ToLowerInvariant().ContainsAnyOf("backup", "mirr");
                //bool nextContainsPreview = nextLine.ToLowerInvariant().ContainsAnyOf("prev", "image", "gallery");
                if (containsUrl)
                {
                    if(ExtractLinkInfo(line))
                        continue;
                }
                else //link probably in next line
                {
                    //ExtractLinkInfoFromAnotherLine
                    if (ExtractLinkInfoFromAnotherLine(line, nextLine, ref i))
                        continue;
                }
            }
        }
        static Regex hasLinkWithNumber = new Regex(@"^(link)\s*(\d)+([\s]|$)", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
        static Regex regPartAndLink = new Regex(@"^(part[s]?|link[s]?)\s*(\d)+\s*[:|=]?\s*(www.+|http.+)([\s]|$)", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
        private bool GetPartAndLink(string line, ref string part, ref string link)
        {
            var matchPart = regPartAndLink.Matches(line);
            if (matchPart.Count > 0 && matchPart[0].Groups.Count == 5)
            {
                part = matchPart[0].Groups[2].Value;
                link = matchPart[0].Groups[3].Value;
                return true;
            }
            return false;
        }

        static Regex regMirrorAndLink = new Regex(@"(link|backups|backup|back?|mir[r]?or[s]?)\s*(\d)?\s*[:|=]?\s*(www.+|http.+)([\s]|$)", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
        private bool GetMirrorAndLink(string line, ref string part, ref string link)
        {
            var matchPart = regMirrorAndLink.Matches(line);
            if (matchPart.Count > 0 && matchPart[0].Groups.Count == 5)
            {
                part = matchPart[0].Groups[2].Value;
                link = matchPart[0].Groups[3].Value;
                return true;
            }
            return false;
        }

        static Regex regPartAndPreview = new Regex(@"^(preview[s]|image|gallery|img)\s*(\d)?\s*[:|=]?\s*(www.+|http.+)([\s]|$)", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
        private bool GetPartAndPreview(string line, ref string part, ref string link)
        {
            var matchPart = regPartAndPreview.Matches(line);
            if (matchPart.Count > 0 && matchPart[0].Groups.Count == 5)
            {
                part = matchPart[0].Groups[2].Value;
                link = matchPart[0].Groups[3].Value;
                return true;
            }
            return false;
        }

        public void Analyze()
        {
            int partIndex = 0, prevIndex = 0;

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
                        Parts.Add($"PART:{index} -> {link}");
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

                    ExtractLink(line, nextLine, "Link", ref i, Downloads);
                    //var linkMatch = regSingleLink.Match(line);
                    //if (linkMatch.Success)
                    //{
                    //    Downloads.Add(linkMatch.Value);
                    //    FilteredOutput.Add(line);
                    //}
                    //else
                    //{
                    //    linkMatch = regSingleLink.Match(nextLine);
                    //    if (linkMatch.Success)
                    //    {
                    //        Downloads.Add(linkMatch.Value);
                    //        i++;
                    //        FilteredOutput.Add("LINK:" + linkMatch.Value);
                    //    }
                    //}
                    continue;
                }

                if (line.ToLowerInvariant().Contains("preview"))
                {
                    var matchPart = regPreviewss.Matches(line);
                    if (matchPart.Count > 0 && matchPart[0].Groups.Count == 3)
                    {
                        string index = matchPart[0].Groups[2].Value;
                        string link = matchPart[0].Groups[3].Value;
                        FilteredOutput.Add(line);
                        Parts.Add($"PREV:{index} -> {link}");
                    }
                    else
                    {
                        ExtractLink(line, nextLine, "Preview", ref i, Previews);
                    }
                    continue;
                }
            }
        }

        private string ExtractLink(string line, string nextLine, string title, ref int i, List<string> list)
        {
            string result = null;
            if(!linkCounter.ContainsKey(title))
                linkCounter.Add(title, 0);

            var linkMatch = regSingleLink.Match(line);
            if (linkMatch.Success)
            {
                result = linkMatch.Value;
                list.Add(result);
                FilteredOutput.Add(line);
                linkCounter[title]++;
            }
            else
            {
                linkMatch = regSingleLink.Match(nextLine);
                if (linkMatch.Success)
                {
                    result = linkMatch.Value;
                    list.Add(result);
                    linkCounter[title]++;
                    FilteredOutput.Add($"{title} {linkCounter[title]}: {result}");
                    i++;
                }
            }

            return result;
        }

        public List<string> ControlWords { get; set; } = new List<string>(new string []
        {
            "Link", "Backup", "Preview",
            "Password", "Pass", "Passwort",
            "DL Key", "Key", "DLKey"
        });
    }
}