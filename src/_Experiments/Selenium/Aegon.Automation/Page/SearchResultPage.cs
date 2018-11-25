using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aegon.Page;
using OpenQA.Selenium;

namespace Aegon
{
    public class SearchResultPage: MasterPage
    {
        public By SearchTextBox = By.Id("ctl00_MainContentPlaceHolder_SearchBox");
        public By SearchButton = By.Id("ctl00_MainContentPlaceHolder_SubmitSearch");

        public By SearchResultRowLocator = By.CssSelector("#search-results>li>div"); 

        public void Search(string keyword)
        {
            FindElement(SearchTextBox).SendKeys(keyword);
            FindElement(SearchButton).Click();
        }

        public By ResultPerPagelocator = By.Id("ctl00_MainContentPlaceHolder_TopPaging_ResultPerPage");
        public By NextLinkLocator = By.Id("ctl00_MainContentPlaceHolder_TopPaging_NextLinkButton");

        public void ChangeResultPerPage(string resultPerPage)
        {
            FindElement(By.Id("ctl00_MainContentPlaceHolder_TopPaging_ResultPerPage")).SendKeys(resultPerPage);
            FindElement(By.Id("ctl00_MainContentPlaceHolder_TopPaging_ResultPerPageButton")).Click();
        }
    }
}
