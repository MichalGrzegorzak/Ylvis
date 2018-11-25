using System;
using System.Linq;
using Aegon.Extensions;
using Aegon.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Aegon.Page
{
    public class CookieConsentModule : BriPage
    {
        public IWebElement DisabledIconsElements { get { return BodyElement.FindElementSafe(By.CssSelector(".aeg-notallowed-sharing")); } }

        public IWebElement SocialIconsElement { get { return BodyElement.FindElementSafe(By.CssSelector(".aeg-allowed-sharing")); } }

        public IWebElement AcceptSocialCookies { get { return BodyElement.FindElementSafe(By.CssSelector(".aeg-sharing-popup .aeg-btn")); } }

        [FindsBy(How = How.CssSelector, Using = ".aeg-cookie-bottom-panel")]
        private IWebElement _cookieConsentPrompt = null;
        public IWebElement CookieConsentPrompt { get { return _cookieConsentPrompt.GetElementSafe(); } }

        [FindsBy(How = How.CssSelector, Using = ".aeg-cookie-consent-module a.js-accept-all")]
        private IWebElement _acceptAllCookies = null;
        public IWebElement AcceptAllCookies1 { get { return _acceptAllCookies.GetElementSafe(); } }

        public bool IsCookieFromDomain(string domain)
        {
            return Driver.Manage().Cookies.AllCookies.Any(x => x.Domain.Contains(domain));
        }

        public void HoverOverSelector(string selector)
        {
            DisabledIconsElements.FindElementSafe(By.ClassName(selector)).ClickSafe();
            WebElementExtensions.WaitForElement(Driver, TimeSpan.FromSeconds(20),
                                                By.ClassName("aeg-sharing-popup"));
        }

        public void WaitForSocialIconsToLoad()
        {
            WebElementExtensions.WaitForElement(Driver, TimeSpan.FromSeconds(20),
                                                By.ClassName("aeg-allowed-sharing"));
        }

        public void ChangeCofiguration()
        {
            Driver.Manage().Cookies.DeleteCookieNamed("cookie_acceptance_level");
            Driver.Manage().Cookies.AddCookie(new Cookie("cookie_acceptance_level","1234-3"));
        }

        public void AcceptAllCookies()
        {
            AcceptAllCookies1.ClickAndWaitForPageToLoad(Driver);
        }

        public void ClickAcceptSocialCookies()
        {
            AutomationHelper.Wait(AcceptSocialCookies.ClickSafe, TimeSpan.FromSeconds(10));
        }
    }
}
