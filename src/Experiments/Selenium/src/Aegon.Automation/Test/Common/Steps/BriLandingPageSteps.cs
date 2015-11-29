using Aegon.Page;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class BriLandingPageSteps : Base.Base
    {
        [Given(@"I am on Landing page on Aegon(.*)")]
        public void GivenIAmOnLandingPageOnAegon(string site)
        {
            SignInToEnvironment();
            Driver.Navigate().GoToUrl(BriLandingPageUrl);
        }

        [Then(@"I see a hero image teaser on the top")]
        public void ThenISeeAHeroImageTeaserOnTheTop()
        {
            var briLandingPage = new BriLandingPage();
            Assert.IsTrue(FindElement(briLandingPage.HeroImageTeaserLocator).Displayed);
        }


        [Then(@"I see first Image block with title (.*)")]
        public void ThenISeeFirstImageBlockWithText(string text)
        {
            var briLandingPage = new BriLandingPage();
            Assert.IsTrue(
                    FindElement(briLandingPage.FirstImageTeaserBlockLocator).Text.ToLower().Contains(text.ToLower()));
        }

        [Then(@"I see second Image block with title (.*)")]
        public void ThenISeeSecondImageBlockWithText(string text)
        {
            var briLandingPage = new BriLandingPage();
            Assert.IsTrue(
                FindElement(briLandingPage.SecondImageTeaserBlockLocator).Text.ToLower().Contains(text.ToLower()));
        }

        [Then(@"I see thrid Image block with title (.*)")]
        public void ThenISeeThridImageBlockWithText(string text)
        {
            var briLandingPage = new BriLandingPage();
            Assert.IsTrue(
                FindElement(briLandingPage.ThirdImageTeaserBlockLocator).Text.ToLower().Contains(text.ToLower()));
        }

        [Then(@"I see fourth Image block with title (.*)")]
        public void ThenISeeFourthImageBlockWithText(string text)
        {
            var briLandingPage = new BriLandingPage();
            Assert.IsTrue(
                FindElement(briLandingPage.FourthImageTeaserBlockLocator).Text.ToLower().Contains(text.ToLower()));
        }

    }
}
