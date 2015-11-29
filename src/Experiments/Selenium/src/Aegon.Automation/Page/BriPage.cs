using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aegon.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Aegon.Page
{
    public class BriPage : BasePage
    {
        #region Page elements

        [FindsBy(How = How.CssSelector, Using = "#logo a")]
        private IWebElement _desktopLogoLinkElement = null;
        public IWebElement DesktopLogoLinkElement
        {
            get { return _desktopLogoLinkElement.GetElementSafe(); }
        }

        [FindsBy(How = How.CssSelector, Using = "#logoresponsive a")]
        private IWebElement _mobileLogoLinkElement = null;
        public IWebElement MobileLogoLinkElement
        {
            get { return _mobileLogoLinkElement.GetElementSafe(); }
        }

        public IWebElement LogoLinkElement
        {
            get
            {
                if (DesktopLogoLinkElement != null && DesktopLogoLinkElement.Displayed)
                    return DesktopLogoLinkElement;

                if (MobileLogoLinkElement != null && MobileLogoLinkElement.Displayed)
                    return MobileLogoLinkElement;

                return null;
            }
        }

        [FindsBy(How = How.CssSelector, Using = "ul.aeg-breadcrumbs")]
        private IWebElement _breadcrumbBlock;
        public IWebElement BreadcrumbBlock
        {
            get { return _breadcrumbBlock.GetElementSafe(); }
        }

        #endregion

        public void ClickOnTheLogoLink()
        {
            LogoLinkElement.ClickAndWaitForPageToLoad(Driver);
        }
    }
}
