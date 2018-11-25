using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Aegon.Extensions;
using Aegon.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Aegon.Page
{
    public class BriOfficeOverviewPage : BriPage
    {
        #region Page elements

        [FindsBy(How = How.CssSelector, Using = "#mainMap")]
        private IWebElement _mainMapElement = null;
        public IWebElement MainMapElement { get { return _mainMapElement.GetElementSafe(); } }

        [FindsBy(How = How.CssSelector, Using = ".aeg-search-location .aeg-f-search")]
        private IWebElement _officeSearchBox = null;
        public IWebElement OfficeSearchBox { get { return _officeSearchBox.GetElementSafe(); } }

        [FindsBy(How = How.CssSelector, Using = ".aeg-search-location .aeg-btn-submit")]
        private IWebElement _officeSearchButton = null;
        public IWebElement OfficeSearchButton { get { return _officeSearchButton.GetElementSafe(); } }

        [FindsBy(How = How.CssSelector, Using = ".aeg-contact-rows .js-aeg-location")]
        private IList<IWebElement> _officeElements = null;
        public IList<IWebElement> OfficeElements { get { return _officeElements; } }

        [FindsBy(How = How.CssSelector, Using = ".nivo-lightbox-overlay #routePopup")]
        private IWebElement _routePopupElement = null;
        public IWebElement RoutePopupElement { get { return _routePopupElement.GetElementSafe(); } }

        [FindsBy(How = How.CssSelector, Using = ".nivo-lightbox-overlay .nivo-lightbox-close")]
        private IWebElement _routePopupCloseButton = null;
        public IWebElement RoutePopupCloseButton { get { return _routePopupCloseButton.GetElementSafe(); } }

        public const string RouteMapSelector = ".nivo-lightbox-overlay .route-map-canvas";

        [FindsBy(How = How.CssSelector, Using = RouteMapSelector)]
        private IWebElement _routeMapElement = null;
        public IWebElement RouteMapElement { get { return _routeMapElement.GetElementSafe(); } }

        #endregion

        public bool IsMainMapDisplayed()
        {
            if (MainMapElement == null)
                return false;

            return IsGoogleMapDisplayed(MainMapElement);
        }

        private bool IsGoogleMapDisplayed(IWebElement containerElement)
        {
            var mapElements = containerElement
                .FindElements(By.CssSelector("div.gm-style"))
                .Where(x => x.Displayed);

            return mapElements.Count() > 0;
        }

        public BriOfficeItem[] GetOffices()
        {
            return OfficeElements
                .Select(x => ObjectFactory.Create<BriOfficeItem>(x))
                .ToArray();
        }

        public void PerformSearch(string city)
        {
            OfficeSearchBox.SendKeys(city);
            Thread.Sleep(250);
            OfficeSearchButton.ClickAndWaitForPageToLoad(Driver);
        }

        public void OpenRoutePopup(BriOfficeItem office)
        {
            office.ShowRouteButton.ClickAndWaitForElement(Driver, By.CssSelector(RouteMapSelector));
        }

        public bool IsRoutePopupDisplayed()
        {
            AutomationHelper.WaitSeconds(3);
            return RoutePopupElement != null ? RoutePopupElement.Displayed : false;
        }

        internal bool IsRouteMapDisplayed()
        {
            return RouteMapElement != null ? IsGoogleMapDisplayed(RouteMapElement) : false;
        }

        public void HideRoutePopup()
        {
            RoutePopupCloseButton.ClickSafe();
            AutomationHelper.WaitSeconds(1);
        }
    }

    public class BriOfficeItem
    {
        [ElementSelector(How = How.CssSelector, Using = ".aeg-street-address h2", Source = ValueSourceEnum.Text)]
        public string OfficeName { get; set; }

        [ElementSelector(How = How.CssSelector, Using = ".aeg-address-controls .aeg-route", Source = ValueSourceEnum.Text, Pattern = @"\s(\d+[\.|,]\d+)km")]
        public string DistanceText { get; set; }

        [ElementSelector(How = How.CssSelector, Using = ".js-showRoute", Source = ValueSourceEnum.Element)]
        public IWebElement ShowRouteButton { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public decimal? DistanceValue
        {
            get
            {
                if (string.IsNullOrWhiteSpace(DistanceText))
                    return null;
                
                decimal val;
                string str = DistanceText.Replace(',', '.');

                if (decimal.TryParse(str, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out val))
                    return val;

                return null;
            }
        }
    }
}
