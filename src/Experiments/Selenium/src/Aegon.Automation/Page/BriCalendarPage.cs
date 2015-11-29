using System;
using System.Collections.Generic;
using System.Linq;
using Aegon.Base;
using Aegon.Helpers;
using Aegon.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Aegon.Page
{
    public class BriCalendarPage : BriPage
    {
        #region Page elements

        [FindsBy(How = How.Id, Using = "ctl00_MainContentPlaceHolder_CalendarContainer_ctl00_TimeZoneDropDown")]
        private IWebElement _timeZoneListElement = null;
        public IWebElement TimeZoneListElement { get { return _timeZoneListElement.GetElementSafe(); } }

        [FindsBy(How = How.Id, Using = "ctl00_MainContentPlaceHolder_CalendarContainer_ctl00_TimeZoneDropDown-button")]
        private IWebElement _fancyTimeZoneButtonElement = null;
        public IWebElement FancyTimeZoneButtonElement { get { return _fancyTimeZoneButtonElement.GetElementSafe(); } }

        public const string FancyTimeZoneListId = "ctl00_MainContentPlaceHolder_CalendarContainer_ctl00_TimeZoneDropDown-menu";
        [FindsBy(How = How.Id, Using = FancyTimeZoneListId)]
        private IWebElement _fancyTimeZoneListElement = null;
        public IWebElement FancyTimeZoneListElement { get { return _fancyTimeZoneListElement.GetElementSafe(); } }

        [FindsBy(How = How.CssSelector, Using = "div.aeg-timezone p")]
        private IWebElement _disclaimerElement = null;
        public IWebElement DisclaimerElement { get { return _disclaimerElement.GetElementSafe(); } }

        #endregion

        public KeyValuePair<string, string> FindTimeZoneDropDownOption(string timeZoneId)
        {
            var options = WebElementHelper.GetSelectOptions(TimeZoneListElement);
            return options.FirstOrDefault(x => x.Key == timeZoneId);
        }

        public void SelectTimeZone(string timeZoneName)
        {
            FancyTimeZoneButtonElement.ClickAndWaitForElement(Driver, By.Id(FancyTimeZoneListId));

            var fancyOption = WebElementHelper.GetFancySelectOptions(FancyTimeZoneListElement).First(x => x.Key == timeZoneName);
            fancyOption.Value.ClickAndWaitForPageToLoad(Driver);
        }
    }
}
