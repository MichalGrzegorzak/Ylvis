using System;
using TechTalk.SpecFlow;

using System.Threading;

using OpenQA.Selenium;
using NUnit.Framework;

namespace Aegon
{
    [Binding]
    public class QuarterlyResultsTestSteps: Base.Base
    {
        [Given(@"I am on Quarterly results page")]
        public void GivenIAmOnQuarterlyResultsPage()
        {   
          //  QuarterlyResultsPage quarterlyResultsPage = new QuarterlyResultsPage();
          //  Driver.Navigate().GoToUrl(quarterlyResultsPage.PageUrl);

            SignInToEnvironment();
            Driver.Navigate().GoToUrl(QuarterlyResultsPageUrl);

        }

        [Then(@"the page title is (.*)")]
        public void ThenThePageTitleIs(string title)
        {
            Console.WriteLine(Driver.Title.ToLower());
            Assert.IsTrue(Driver.Title.ToLower().Contains(title.ToLower()));
        }
        [Then(@"I see youtube video on the page")]
        public void ThenISeeYoutubeVideoOnThePage()
        {
            QuarterlyResultsPage quarterlyResultsPage = new QuarterlyResultsPage();
            Assert.IsTrue(FindElement(quarterlyResultsPage.YouTubePlayerLocator).Displayed);
        }
        
        [Then(@"I see LHS navigation")]
        public void ThenISeeLhsNavigation()
        {
            QuarterlyResultsPage quarterlyResultsPage = new QuarterlyResultsPage();
            Assert.IsTrue(FindElement(quarterlyResultsPage.LhsNavigationLocator).Displayed);
        }
        
        [Then(@"I see RHS Column")]
        public void ThenISeeRHSColumn()
        {
            QuarterlyResultsPage quarterlyResultsPage = new QuarterlyResultsPage();
            Assert.IsTrue(FindElement(quarterlyResultsPage.RhsColumnLocator).Displayed);
        }

        [Then(@"I see English Press releases html link")]
        public void ThenISeeEnglishPressReleasesHtmllink()
        {
            QuarterlyResultsPage quarterlyResultsPage = new QuarterlyResultsPage();
            string htmlLink = FindElement(quarterlyResultsPage.PressReleasesEnglishHtmlLocator).GetAttribute("href");
            Assert.IsTrue(htmlLink.Length > 6);
        }

        [Then(@"I see English Press releases pdf link")]
        public void ThenISeeEnglishPressReleasesPdflink()
        {
            QuarterlyResultsPage quarterlyResultsPage = new QuarterlyResultsPage();
            string pdfLink = FindElement(quarterlyResultsPage.PressReleasesEnglishPdfLocator).GetAttribute("href");
            Assert.IsTrue(pdfLink.ToLower().Contains(".pdf"));

        }

        [When(@"I click All quarterly results")]
        public void WhenIClickAllQuarterlyResults()
        {
            QuarterlyResultsPage quarterlyResultsPage = new QuarterlyResultsPage();
            FindElement(quarterlyResultsPage.AllQuarterlyResultsTabLocator).Click();
        }

        [Then(@"I see the All quarterly results table")]
        public void ThenISeeTheAllQuarterlyResultsTable()
        {
            QuarterlyResultsPage quarterlyResultsPage = new QuarterlyResultsPage();
            Assert.IsTrue(FindElementInMaxTenSec(quarterlyResultsPage.AllQuarterlyResultsTableLocator).Displayed);
        }


        [Then(@"I see current year and four quarterly columns")]
        public void ThenISeeCurrentYearAndFourQuarterlyColumns()
        {
            int currentYear = DateTime.Now.Year;
            Assert.IsTrue(Driver.FindElement(By.XPath("//th[contains(.,"+ currentYear +")]")).Displayed);
            Assert.IsTrue(Driver.FindElement(By.XPath("//th[contains(.,'Q1')]")).Displayed);
            Assert.IsTrue(Driver.FindElement(By.XPath("//th[contains(.,'Q2')]")).Displayed);
            Assert.IsTrue(Driver.FindElement(By.XPath("//th[contains(.,'Q3')]")).Displayed);
        }

    }
}
