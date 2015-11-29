using System.Threading;

using Aegon.Base;

using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{

    public class PerformanceTestsSteps : BaseFeatureSteps
    {
        [Then(@"net panel results are saved")]
        public void ThenNetPanelResultsAreSaved()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"YSlow results are saved")]
        public void ThenYSlowResultsAreSaved()
        {
            Thread.Sleep(5000);
        }
    }    

}
