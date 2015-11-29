using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commons;
using Commons.Html;
using Stock.Core.Domain;

namespace Stock.Core.WebScrapers
{
    public class ParkietExtractor
    {
        public string InputHtml { get; set; }

        public ParkietExtractor(string inputHtml)
        {
            InputHtml = inputHtml;
        }

        
        public void TrimInputBetween(string[] begin, params string[] end)
        {
            string result = HtmlHelper.TextFrom(InputHtml, false, begin);
            result = HtmlHelper.TextFrom(result, true, end);
            InputHtml = result;
        }

        public void RemoveEvery(string toRemove)
        {
            InputHtml = InputHtml.Replace(toRemove, "");
        }

        private int CountCompanies(string input)
        {
            string[] res = input.Split(new string[] { "<tr class=" }, StringSplitOptions.RemoveEmptyEntries);
            return res.Length;
        }

        public List<Company> GetCompanies()
        {
            string html = InputHtml;
            int companiesFound = CountCompanies(html);

            int endPosition = 0;
            List<Company> companies = new List<Company>();
            for (int i = 0; i < companiesFound; i++)
            {
                companies.Add(CompanyNames(html));
                endPosition = html.IndexOf("</tr>") + 5;
                html = html.Substring(endPosition);

                if (html.IndexOf("<tr") == -1)
                    break;
            }

            return companies;
        }

        private Company CompanyNames(string input)
        {
            HTMLSearchResult searcher = new HTMLSearchResult(input); //create a simple searcher object
            HTMLSearchResult result; //create a temporary object

            result = searcher.GetTagData("tr");
            string paperCode = HtmlHelper.CutOffValueFromQuotas(result.TAGAttribute, "id=", '"');
            result = searcher.GetTagData("tr").GetTagData("td").GetTagData("a");
            string name = result.TAGData;
            result = searcher.GetTagData("tr").GetTagData("td", 2);
            string id = result.TAGData.Trim();

            Company c = new Company(id);
            c.Name = name;
            c.PaperCode = paperCode;
            return c;
        }
    }
}
