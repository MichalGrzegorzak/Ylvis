using Aegon.Page;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Aegon.Base;
using Aegon.Extensions;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class SidebarModulesSteps : BaseFeatureSteps
    {
        public SidebarModulesSteps()
        {
            CurrentPage = new BriSidebarContentPage();
        }

        public BriSidebarContentPage Page
        {
            get { return CurrentPage as BriSidebarContentPage; }
        }

        [Then(@"Right-hand side column should be visible")]
        public void ThenRightHandSideColumnShouldBeVisible()
        {
            Assert.IsNotNull(Page.SidebarBlock, "RHS column should be visible.");
        }

        [Then(@"I should see (.*) modules in right-hand side column")]
        public void ThenIShouldSeeModulesInRightHandSideColumn(int numberOfModules)
        {
            Assert.IsTrue(Page.SidebarModules.Count == numberOfModules, string.Format("There should be {0} modules in RHS column", numberOfModules));
        }

    }
}
