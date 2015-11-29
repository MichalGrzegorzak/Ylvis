using System;
using System.Threading;
using Aegon.Base;
using Aegon.Page;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Aegon
{
    [Binding]
    public class CookieWidgetChecksSteps : BaseFeatureSteps
    {
        public CookieWidgetChecksSteps()
        {
            CurrentPage = new MasterPage();
        }

        public MasterPage Page {
            get { return CurrentPage as MasterPage; }
        }

        [Then(@"I see cookie widget with (.*)")]
        public void ThenIShouldSeeCookieWidgetWith(string title)
        {
            var masterPage = new MasterPage();
            Assert.IsTrue(Page.CookieWidgetTitleLocator.Text.ToLower().Contains(title.ToLower()));
        }
        
        [Then(@"I see I agree button")]
        public void ThenIShouldSeeIAgreeButton()
        {
            var masterPage = new MasterPage();
            Assert.IsTrue(Page.CookieWidgetIAgreeButton.Displayed);
        }

        [Given(@"I see cookie widget")]
        public void GivenISeeCookieWidget()
        {
            var masterPage = new MasterPage();
            Assert.IsTrue(Page.CookieWidgetLocator.Displayed);
        }

        [When(@"I click I agree button")]
        public void WhenIClickIAgreeButton()
        {
            var masterPage = new MasterPage();
            Page.CookieWidgetIAgreeButton.Click();
        }

        [Then(@"the cookie widget disappears")]
        public void ThenTheCookieWidgetDisappears()
        {
            var masterPage = new MasterPage();
            Thread.Sleep(3000);
            Assert.IsFalse(Page.CookieWidgetLocator.Displayed);
        }

    }
}
