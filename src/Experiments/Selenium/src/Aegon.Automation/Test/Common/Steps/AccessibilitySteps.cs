using System.Linq;
using Aegon.Page;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Aegon.Base;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class AccessibilitySteps : BaseFeatureSteps
    {
        public AccessibilitySteps()
        {
            CurrentPage = new BriHomePage();
        }

        public BriHomePage Page
        {
            get { return CurrentPage as BriHomePage; }
        }

        [Then(@"After max (.*) tabbing I should go to the first footer link")]
        public void ThenAfterTabbingIShouldGoToTheLink(int maxTabs)
        {
            var found = false;
            var footerLink = Page.FooterLinksElements.First();

            for (int i = 0; i < maxTabs; i++)
            {
                // send tab
                AppBrowser.SendKeys("\t");
                
                // get focused element
                var activeElement = Page.GetActiveElement();

                // check if current focused element is the first footer link
                if (footerLink.Equals(activeElement))
                {
                    found = true;
                    break;
                }
            }

            Assert.IsTrue(found);
        }
    }
}
