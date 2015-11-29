using Aegon.Base;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Aegon
{
    [Binding]
    public class CustomErrorPageChecksForAllSitesSteps : BaseFeatureSteps
    {
        public CustomErrorPageChecksForAllSitesSteps()
        {
            CurrentPage = new CustomErrorPage();
        }

        public CustomErrorPage Page {
            get { return CurrentPage as CustomErrorPage; }
        }

        [Then(@"I am directed to custom error page with title (.*)")]
        public void ThenIShouldBeDirectedToCustomErrorPageWithTitle(string title)
        {
             Assert.IsTrue(Page.CustomErrorPageTitle.Contains(title.ToLower()), "Page doesn't have valid page title");
        }
    }
}
