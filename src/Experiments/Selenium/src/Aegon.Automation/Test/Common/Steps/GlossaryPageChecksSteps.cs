using System.Linq;
using System.Threading;
using Aegon.Base;
using Aegon.Page;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class GlossaryPageChecksSteps : BaseFeatureSteps
    {
        public GlossaryPageChecksSteps()
        {
            CurrentPage = new GlossaryPage();
        }

        public GlossaryPage Page {
            get { return CurrentPage as GlossaryPage; }
        }
        
        [When(@"I click the link (.*)")]
        public void WhenIClickTheLink(string linkText)
        {
            Thread.Sleep(250);
            var linkElement = Page.FindItemTriggerElement(linkText);
            Assert.IsNotNull(linkElement, string.Format("Item: \"{0}\" not found.", linkText));
            linkElement.Click();
        }
        
        [Then(@"I should see the description (.*)")]
        public void ThenIShouldSeeTheDescription(string descriptionText)
        {
            Thread.Sleep(3000);
            var descriptionElements = Page.GetDescriptionElements();
            Assert.IsTrue(descriptionElements.Count() == 1, "Only one glossary item should be oepened.");
            Assert.IsTrue(descriptionElements.First().Text.Equals(descriptionText), "Glossary item content not match.");
        }
    }
}
