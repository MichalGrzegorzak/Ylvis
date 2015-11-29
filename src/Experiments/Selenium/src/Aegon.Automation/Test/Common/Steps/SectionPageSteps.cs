using Aegon.Page;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class SectionPageSteps : Base.Base
    {
        [Given(@"I am on Section page of Aegon (.*)")]
        public void GivenIAmOnSectionPageOfAegon(string site)
        {
            SignInToEnvironment();
            Driver.Navigate().GoToUrl(SectionPageUrl);
        }
        
        [Then(@"I see the page title (.*)")]
        public void ThenISeeThePageTitle(string title)
        {
            AssertTitleContains(title);
        }
        
        [Then(@"I see the first teaser panel with text (.*)")]
        public void ThenISeeTheFirstTeaserPanelWithText(string text)
        {
            var sectionPage = new SectionPage();
            Assert.IsTrue(FindElement(sectionPage.FirstTeaserLocator).Text.ToLower().Contains(text.ToLower()));
        }

        [Then(@"I see the second teaser panel with text (.*)")]
        public void ThenISeeTheSecondTeaserPanelWithText(string text)
        {
            var sectionPage = new SectionPage();
            Assert.IsTrue(FindElement(sectionPage.SecondTeaserLocator).Text.ToLower().Contains(text.ToLower()));
        }

        [Then(@"I see the third teaesr panel with text (.*)")]
        public void ThenISeeTheThirdTeaesrPanelWithText(string text)
        {
            var sectionPage = new SectionPage();
            Assert.IsTrue(FindElement(sectionPage.ThirdTeaserLocator).Text.ToLower().Contains(text.ToLower()));
        }
        
        [Then(@"I see the fourth teaser panel with text (.*)")]
        public void ThenISeeTheFourthTeaserPanelWithText(string text)
        {
            var sectionPage = new SectionPage();
            Assert.IsTrue(FindElement(sectionPage.FourthTeaserLocator).Text.ToLower().Contains(text.ToLower()));
        }
    }
}
