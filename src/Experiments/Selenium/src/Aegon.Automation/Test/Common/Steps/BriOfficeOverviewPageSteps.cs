using System.Linq;
using Aegon.Page;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Aegon.Base;
using Aegon.Extensions;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class BriOfficeOverviewPageSteps : BaseFeatureSteps
    {
        public BriOfficeOverviewPageSteps()
        {
            CurrentPage = new BriOfficeOverviewPage();
        }

        public BriOfficeOverviewPage Page
        {
            get { return CurrentPage as BriOfficeOverviewPage; }
        }

        [Then(@"I should see a google map on the page")]
        public void ThenIShouldSeeAGoogleMapOnThePage()
        {
            Assert.IsTrue(Page.IsMainMapDisplayed(), "Main map should be visible");

            Assert.IsFalse(Page.IsRoutePopupDisplayed(), "Route popup should be hidden");
        }

        [Then(@"I should see a list of offices")]
        public void ThenIShouldSeeAListOfOffices()
        {
            Assert.NotNull(Page.OfficeElements, "List of offices should not be empty.");
            Assert.IsTrue(Page.GetOffices().Length > 1, "There should be at least one office displayed on the page.");
        }

        [When(@"I try to find the nearest office to (.*)")]
        public void WhenITryToFindTheNearestOfficeTo(string city)
        {
            Page.PerformSearch(city);
        }

        [Then(@"I should see an ordered by distance office list")]
        public void ThenIShouldSeeAnOrderedOfficeList()
        {
            var offices = Page.GetOffices();

            Assert.IsFalse(offices.Any(x => !x.DistanceValue.HasValue), "All offices must have not null distance value");

            CollectionAssert.IsOrdered(offices.Select(x => x.DistanceValue.Value), "Offices list should be ordered by distance value");
        }

        [Then(@"It should be found max (.*) offices")]
        public void ThenItShouldBeFoundMaxOffices(int maxOffices)
        {
            Assert.IsTrue(Page.GetOffices().Length <= maxOffices);
        }

        [When(@"I click the show route to (.*)")]
        public void WhenIClickTheShowRouteIcon(string destinationOffice)
        {
            var offices = Page.GetOffices();
            var destOffice = offices.FirstOrDefault(x => x.OfficeName == destinationOffice);

            Assert.IsNotNull(destOffice, "Destination office must be present on the list");
            Assert.IsNotNull(destOffice.ShowRouteButton);

            // open popup
            Page.OpenRoutePopup(destOffice);
        }

        [Then(@"I should see a popup with a route")]
        public void ThenIShouldSeeAPopupWithARoute()
        {
            Assert.IsTrue(Page.IsRoutePopupDisplayed(), "Route popup should be displayed");

            Assert.IsTrue(Page.IsRouteMapDisplayed(), "Map on the route popup should be displayed");
        }

        [When(@"I click the close route popup button")]
        public void WhenIClickTheCloseRoutePopupButton()
        {
            Page.HideRoutePopup();
        }

        [Then(@"The route overlay should be hidden")]
        public void ThenTheRouteOverlayShouldBeHidden()
        {
            Assert.IsFalse(Page.IsRoutePopupDisplayed(), "Route popup should be hidden");
        }
    }
}
