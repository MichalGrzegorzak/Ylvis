using Aegon.Page;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Aegon.Test.Aegon.pl.Steps
{
    [Binding]
    public class UserShouldSeeMapOnAegonPlSiteSteps : Base.Base
    {
        [Given(@"I am on office overview page of (.*)")]
        public void GivenIAmOnOfficeOverviewPageOf(string site)
        {
            Driver.Navigate().GoToUrl(OfficeOverviewPageUrl);
        }
        
        [Then(@"I see a google map on the page")]
        public void ThenISeeAGoogleMapOnThePage()
        {
            var officeOVerviewPage = new OfficeOverviewPage();
            Assert.IsTrue(FindElement(officeOVerviewPage.MapLocator).Displayed);
        }
        
        [Then(@"I see a list of addresses under the map")]
        public void ThenISeeAListOfAddressesUnderTheMap()
        {
            var officeOVerviewPage = new OfficeOverviewPage();
            Assert.IsTrue(FindElement(officeOVerviewPage.AddressesLocator).Displayed);
        }

        [When(@"I search for offices near to (.*)")]
        public void WhenISearchForOfficesNearTo(string location)
        {
            var officeOVerviewPage = new OfficeOverviewPage();
            officeOVerviewPage.FindNearestOffice(location);
        }

        [Then(@"I see (.*) on the top of the list")]
        public void ThenIShouldSeeOfficeOnTheTopOfTheList(string office)
        {
            var officeOVerviewPage = new OfficeOverviewPage();
            Assert.IsTrue(FindElement(officeOVerviewPage.AddressesLocator).Text.ToLower().Contains(office.ToLower()));
        }

        [Then(@"the distance is (.*) km")]
        public void ThenTheDistanceIsKm(string distance)
        {
            var officeOVerviewPage = new OfficeOverviewPage();
            Assert.IsTrue(FindElement(officeOVerviewPage.AddressesLocator).Text.Contains(distance));
        }


        [When(@"I set the region to (.*)")]
        public void WhenISetTheRegionTo(string region)
        {
            var officeOVerviewPage = new OfficeOverviewPage();
            officeOVerviewPage.SelectRegion(region);
        }

        

    }
}
