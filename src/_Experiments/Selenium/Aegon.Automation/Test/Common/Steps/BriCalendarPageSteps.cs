using Aegon.Page;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Aegon.Base;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class BriCalendarPageSteps : BaseFeatureSteps
    {
        public BriCalendarPageSteps()
        {
            CurrentPage = new BriCalendarPage();
        }

        public BriCalendarPage Page
        {
            get { return CurrentPage as BriCalendarPage; }
        }

        [Then(@"I should see localized timezone (.*) label (.*)")]
        public void ThenIShouldSeeTimezoneDropdown(string timeZoneId, string timeZoneName)
        {
            Assert.IsNotNull(Page.TimeZoneListElement);

            var option = Page.FindTimeZoneDropDownOption(timeZoneId);

            Assert.IsNotNull(option);
            Assert.AreEqual(timeZoneName, option.Value);
        }

        [Then(@"I select (.*) timezone")]
        public void ThenISelectTimezone(string timeZoneName)
        {
            Page.SelectTimeZone(timeZoneName);
        }

        [Then(@"I should see timezone name (.*) in disclaimer text")]
        public void ThenIShouldSeeTimezoneNameText(string timeZoneName)
        {
            Assert.IsNotNull(Page.DisclaimerElement);
            Assert.IsTrue(Page.DisclaimerElement.Text.Contains(timeZoneName));
        }

    }
}
