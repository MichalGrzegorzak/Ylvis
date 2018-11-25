using Aegon.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class FundsAndFundOverviewSteps : Base.Base
    {
       [Given(@"I am on Fund overview page of (.*)")]
        public void GivenIAmOnFundOverviewPageOf(string site)
        {
            SignInToEnvironment();
            Driver.Navigate().GoToUrl(FundOverViewPageUrl);
        }
        
        [Given(@"I set the product to (.*)")]
        public void GivenISetTheProductTo(string product)
        {
            var fundOverviewPage = new FundOverviewPage();
            fundOverviewPage.SetProduct(product);

        }

        [Given(@"I set the currency to (.*)")]
        public void GivenISetTheCurrencyTo(string currency)
        {
            var fundOverviewPage = new FundOverviewPage();
            fundOverviewPage.SetCurrency(currency);
        }

        
        [When(@"I click the filter button")]
        public void WhenIClickTheFilterButton()
        {
            var fundOverviewPage = new FundOverviewPage();
           fundOverviewPage.ClickFilterButton();
        }
        
        [Then(@"I see the fund (.*)")]
        public void ThenISeeTheFund(string fund)
        {
            Assert.IsTrue(FindElement(By.XPath("//a[contains(text(),'" + fund + "')]")).Displayed);
        }

        [Given(@"I click the fund (.*)")]
        public void GivenIClickTheFund(string fund)
        {
            var fundOverviewPage = new FundOverviewPage();
            fundOverviewPage.ClickFund(fund);
        }

        [Then(@"I am directed to fund (.*) page")]
        public void ThenIAmDirectedToFundPage(string fund)
        {
            AssertTitleContains(fund);
        }

        [Then(@"I see the pichart for the fund")]
        public void ThenISeeThePichartForTheFund()
        {
            var fundPage = new FundPage();
            Assert.IsTrue(FindElement(fundPage.PiChartLocator).Displayed);
        }

        [Then(@"I can change the historic fund period to (.*)")]
        public void ThenICanChangeTheHistoricFundPeriodToMiesiecy(string period)
        {
            var fundPage = new FundPage();
            fundPage.ChangeHistoricFundPeriod(period);
        }


    }
}
