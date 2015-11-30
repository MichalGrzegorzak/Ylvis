using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Commons;
using MbUnit.Framework;
using Rhino.Commons;
using Rhino.Commons.NHibernate;
using Stock.Core.Controller;
using Stock.Core.Domain;
using NHibernate.Exceptions;
using NHibernate.Linq;
using System.Linq;
using System.Linq.Dynamic;
using Stock.Core.WebScrapers;
using Stock.Test.ServiceReference1;
using linqExpression = System.Linq.Expressions;

namespace Stock.Test.WebScrapeTests
{
    [TestFixture]
    public class ParkietExtractionFixture 
    {
        [Test]
        public void Test1_ResourceAvaible()
        {
            Assert.IsTrue(!String.IsNullOrEmpty(SourcetHtml));
        }

        [Test]
        public void Test2_ExtractionIsCorrect()
        {
            ParkietExtractor extractor = new ParkietExtractor(SourcetHtml);
            extractor.TrimInputBetween(new string[] { "<div class=\"quotations\">", "<tbody>" }, new string[] { "</tbody>", "</table>" });

            //check beginning
            int idx = extractor.InputHtml.IndexOf("abc"); 
            Assert.IsTrue(idx == 0);

            //check ending
            idx = extractor.InputHtml.IndexOf("</table>");
            int textLength = extractor.InputHtml.Length - 8;
            Assert.IsTrue(idx == textLength);
        }

        [Test]
        public void Test3_DataVerification()
        {
            ParkietExtractor extractor = new ParkietExtractor(SourcetHtml);
            extractor.TrimInputBetween(new [] { "<div class=\"quotations\">", "<tbody>" }, "</tbody>");
            extractor.RemoveEvery("abc");

            List<Company> companies = extractor.GetCompanies();
            Assert.IsTrue(companies.Count == 4);
            //
            Company c = companies[2];
            Assert.IsTrue(c.ID == "06N");
            Assert.IsTrue(c.Name == "06MAGNA");
            Assert.IsTrue(c.PaperCode == "PLNFI0600010");
        }

       
        private string SourcetHtml
        {
            get
            {
                TextReader reader = new StreamReader("WebScrapeTests\\parkietNotowaniaHtml.txt");
                string s = reader.ReadToEnd();
                return s;
            }
        }

        

        #region REST OF DATA To EXTRACT
        //result = searcher.GetTagData("tr").GetTagData("td", 3);
        //string data = result.TAGData;
        //result = searcher.GetTagData("tr").GetTagData("td", 4);
        //string cena = result.TAGData;
        //result = searcher.GetTagData("tr").GetTagData("td", 5);
        //string tko = result.TAGData;
        //result = searcher.GetTagData("tr").GetTagData("td", 6);
        //string zmiana = result.TAGData;
        //result = searcher.GetTagData("tr").GetTagData("td", 7);
        //string open = result.TAGData;
        //result = searcher.GetTagData("tr").GetTagData("td", 8);
        //string high = result.TAGData;
        //result = searcher.GetTagData("tr").GetTagData("td", 9);
        //string low = result.TAGData;
        //result = searcher.GetTagData("tr").GetTagData("td", 10);
        //string odniesienie = result.TAGData;
        //result = searcher.GetTagData("tr").GetTagData("td", 11);
        //string v = result.TAGData;
        //result = searcher.GetTagData("tr").GetTagData("td", 12);
        //string obrot = result.TAGData; 
        #endregion

        #region USING REGEX MATCHING EXAMPLE
        //string pattern = "Page views: [0-9,]*";
        //MatchCollection matches = Regex.Matches(input, 
        //    pattern, RegexOptions.ExplicitCapture);
        //List<string> lViews = new List<string>();
        //foreach (Match m in matches)
        //{
        //    int idx = m.Value.LastIndexOf(":") + 2;
        //    //lViews.Add(string.Parse(m.Value.Substring(idx).Replace(",", "")));
        //}
        //return lViews; 
        #endregion
    }
}
