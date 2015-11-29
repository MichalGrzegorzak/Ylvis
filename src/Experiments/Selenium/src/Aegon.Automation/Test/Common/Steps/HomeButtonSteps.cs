using Aegon.Page;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Aegon.Base;
using Aegon.Extensions;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class HomeButtonSteps : BaseFeatureSteps
    {
        public HomeButtonSteps()
        {
            CurrentPage = new BriCalendarPage();
        }

        public BriPage Page
        {
            get { return CurrentPage as BriCalendarPage; }
        }

        [When(@"I click on the logo in the header")]
        public void WhenIClickOnTheLogoInTheHeader()
        {
            Assert.IsNotNull(Page.LogoLinkElement, "Home button should be visible");
            Page.ClickOnTheLogoLink();
        }

        [Then(@"I should be redirected to the (.*) page")]
        public void ThenIShouldBeRedirectedToThePage(string homePageUrl)
        {
            var normalizedUrl = Page.Url.ToLowerInvariant();
            Assert.IsTrue(normalizedUrl.EndsWith(homePageUrl.ToLowerInvariant()), "Expected homepage: " + homePageUrl);
        }

    }
}
