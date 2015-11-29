using System.Collections.Generic;
using Aegon.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class SearchTestOnAegonSitesSteps : Base.Base
    {
        [Given(@"I am on Homepage of Aegon (.*)")]
        public void GivenIAmOnHomepageOfAegon(string site)
        {
            SignInToEnvironment();
            Driver.Navigate().GoToUrl(BaseUrl);
        }
        
        [Given(@"I am on Search Result page of (.*)")]
        public void GivenIAmOnSearchResultPageOf(string site)
        {
            Driver.Navigate().GoToUrl(SearchResultPageUrl);
        }
        
        [Given(@"I am on Contact Us page of (.*)")]
        public void GivenIAmOnContactUsPageOf(string site)
        {
            Driver.Navigate().GoToUrl(ContactUsPageUrl);
        }

        [Then(@"I am directed to search result page with (.*)")]
        public void ThenIAmDirectedToSearchResultPageWith(string title)
        {
            AssertTitleContains(title);
        }

        //[Given(@"I am on Aegon Homepage")]
        //public void GivenIAmOnAegonHomepage()
        //{
        //    Driver.Navigate().GoToUrl(EnvironmentUrl.AegonCom);
        //}

        [Given(@"I search in top navigation the text (.*)")]
        public void GivenISearchTheTextInTheTopNavigation(string keyword)
        {
            //var aegonHomePage = new AegonHomePage();
            //SearchResultPage searchResultPage = aegonHomePage.search(keyword);

            var masterPage = new MasterPage();
            SearchResultPage searchResultPage = masterPage.TopNavSearch(keyword);


        }

        //[Then(@"I am directed to search result page")]
        //public void ThenIAmDirectedToSearchResultPage()
        //{
        //    AssertTitleContains("Search results - Aegon Group");
        //}

        [Then(@"I see pagination on the search result page")]
        public void ThenISeePaginationOnTheSearchResultPage()
        {
            AssertElementPresent(By.Id("ctl00_MainContentPlaceHolder_TopPaging_PageButtonRepeater_ctl01_PageLinkButton"));
            AssertElementPresent(By.Id("ctl00_MainContentPlaceHolder_TopPaging_PageButtonRepeater_ctl02_PageLinkButton"));
        }

        [Then(@"I see Result per page is set to (.*)")]
        public void ThenISeeResultPerPageIsSetTo(string resultPerPage)
        {
            var searchResultpage = new SearchResultPage();
            string s = FindElement(searchResultpage.ResultPerPagelocator).Text;
            Assert.IsTrue(s.Contains(resultPerPage));
        }

        [Then(@"I see link Next for pagination")]
        public void ThenISeeLinkNextForPagination()
        {
            var searchResultpage = new SearchResultPage();
            AssertElementDisplayed(searchResultpage.NextLinkLocator);
        }

        [Then(@"I see only (.*) results per page")]
        public void ThenISeeOnlyResultsPerPage(int numberOfResultsPerPage)
        {
            var searchResultPage = new SearchResultPage();
            // searchResultList = ListOfElements(By.CssSelector("#search-results>li>div"));
            IList<IWebElement> searchResultList = ListOfElements(searchResultPage.SearchResultRowLocator);
            Assert.IsTrue(searchResultList.Count == numberOfResultsPerPage);
        }

        [Given(@"I set Results per page to (.*)")]
        public void GivenISetResultsPerPageTo(string resultsPerPage)
        {
            var searchResultpage = new SearchResultPage();
            searchResultpage.ChangeResultPerPage(resultsPerPage);
        }

        //[Given(@"I am on Search Result page")]
        //public void GivenIAmOnSearchResultPage()
        //{
        //    var searchResultPage = new SearchResultPage();
        //    Driver.Navigate().GoToUrl(searchResultPage.SearchResultPageUrlAegon);
        //}

        [Given(@"I search the text (.*)")]
        public void GivenISearchTheText(string keyword)
        {
            var searchResultPage = new SearchResultPage();
            searchResultPage.Search(keyword);
        }

        [Then(@"I should see search results for (.*)")]
        public void ThenIShouldSeeSearchResultsFor(string keyword)
        {
            var searchResultPage = new SearchResultPage();
            IList<IWebElement> searchResultList = ListOfElements(searchResultPage.SearchResultRowLocator);

            foreach (IWebElement element in searchResultList)
            {
                Assert.IsTrue(element.Text.ToLower().Contains(keyword.ToLower()));
            }
        }

        //[Given(@"I am on Aegon PL Homepage")]
        //public void GivenIAmOnAegonPlHomepage()
        //{

        //    Driver.Navigate().GoToUrl(EnvironmentUrl.AegonPl);
        //}

        //[Given(@"I am on Aegon PL Search Result page")]
        //public void GivenIAmOnAegonPlSearchResultPage()
        //{
        //    var searchResultPage = new SearchResultPage();
        //    Driver.Navigate().GoToUrl(searchResultPage.SearchResultPageUrlAegonPl);
        //}


        //[Then(@"I am directed to Aegon PL search result page")]
        //public void ThenIAmDirectedToAegonPlSearchResultPage()
        //{
        //    AssertTitleContains("Wyniki wyszukiwania - Aegon Polska");
        //}

        //[Given(@"I am on Aegon PL Contact Us page")]
        //public void GivenIAmOnAegonPlContactUsPage()
        //{
        //    var aegonPlContactUsPage = new ContactUsPage();
        //    Driver.Navigate().GoToUrl(aegonPlContactUsPage.contactUsPageUrlAegonPl);
        //}

    }
}
