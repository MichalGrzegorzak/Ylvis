using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

using Aegon.Base;
using Aegon.Base.TestRunner;
using Aegon.Page;

using NUnit.Framework;

namespace Aegon.Test.General
{
    [TestDescriptor(ID = "STATIC_LINKS", Description = "Link checker (only for static.aegon*")]
    internal class StaticLinksCheckerTest : ITest
    {
        BasePage page = null;

        private Dictionary<string, List<string>> pageLinks = new Dictionary<string, List<string>>();        

        public string ID
        {
            get
            {
                return "STATIC_LINKS";
            }
        }

        public void Initialize(TestRunnerEngine runner, WebBrowser webBrowser)
        {
            page = new BasePage();
            page.Initialize(webBrowser.WebDriver);            
        }

        public void Execute(WebBrowser webBrowser)
        {                                  
            var pageSrc = webBrowser.WebDriver.PageSource;
            Regex regx = new Regex("http://static([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\,]*)?", RegexOptions.IgnoreCase);
            var linksMatches = regx.Matches(pageSrc);
            foreach (var linksMatch in linksMatches)
            {
                string link = linksMatch.ToString();
                if(link.EndsWith("/"))
                    continue;                
                if (pageLinks.ContainsKey(link))
                {
                    pageLinks[link].Add(webBrowser.WebDriver.Url);
                }
                else
                {
                    pageLinks.Add(link, new List<string>(){webBrowser.WebDriver.Url});
                }
            }            
        }


        public void FinalExecute(WebBrowser webBrowser)
        {
            StringBuilder brokenLinks = new StringBuilder();

            foreach (var pageLink in pageLinks)
            {
                var link = pageLink.Key;
                Uri urlCheck = new Uri(link);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlCheck);
                request.Timeout = 15000;
                HttpWebResponse response = null;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (Exception ex)
                {
                    brokenLinks.AppendLine("Unable to downlodad link: " + urlCheck + " Exception: " + ex.Message);
                    brokenLinks.Append("Pages that contains link: ");
                    brokenLinks.AppendLine();
                    pageLink.Value.ForEach(l => brokenLinks.AppendLine(l));
                    brokenLinks.AppendLine();
                    continue;
                }

                if (response.StatusCode == HttpStatusCode.InternalServerError
                    || response.StatusCode == HttpStatusCode.NotFound)
                {
                    brokenLinks.AppendLine("Link to static resource broken: " + urlCheck);
                    brokenLinks.Append("Pages that contains link: ");
                    brokenLinks.AppendLine();
                    pageLink.Value.ForEach(l => brokenLinks.AppendLine(l));
                    brokenLinks.AppendLine();
                }
                response.Close();
                
            }

            if (brokenLinks.Length > 0)
            {
                Assert.Fail(brokenLinks.ToString());
            }
        }
    }
}
