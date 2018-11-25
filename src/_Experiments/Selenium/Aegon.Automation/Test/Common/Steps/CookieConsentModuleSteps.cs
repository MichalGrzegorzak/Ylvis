using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Aegon.Base;
using Aegon.Helpers;
using Aegon.Page;
using Aegon.TestAutomationReference;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class CookieConsentModuleSteps : BaseFeatureSteps
    {
        private readonly TimeSpan MaximumCookieConsentWaitTime = TimeSpan.FromSeconds(15);

        public CookieConsentModuleSteps()
        {
            CurrentPage = new CookieConsentModule();
        }

        public CookieConsentModule Page
        {
            get { return CurrentPage as CookieConsentModule; }
        }

        [Then(@"I should see (.*) image")]
        public void ThenIShouldSeeImage(string img)
        {
            Assert.True(Page.DisabledIconsElements.Displayed);
            Assert.False(Page.SocialIconsElement.Displayed);
            var image = Page.DisabledIconsElements.FindElement(By.ClassName(img));
            Assert.True(image.Displayed);
        }

        [Then(@"There is no cookie set in domain like (.*)")]
        public void ThenThereIsNoCookieSetInDomainLike(string domain)
        {
            Assert.False(Page.IsCookieFromDomain(domain));
        }

        [When(@"I hover over (.*) image")]
        public void WhenIHoverOverImage(string img)
        {
            Page.HoverOverSelector(img);
        }

        [Then(@"I should see social sharing icons")]
        public void ThenIShouldSeeSocialSharingIcons()
        {
            Page.WaitForSocialIconsToLoad();
            Assert.True(Page.SocialIconsElement.Displayed);
        }

        [Then(@"Configuraion has changed")]
        public void ThenConfiguraionHasChanged()
        {
            Page.ChangeCofiguration();
        }

        [Then(@"Cookie prompt is displayed")]
        public void ThenCookiePromptIsDisplayed()
        {
            AutomationHelper.Wait(() => Page.CookieConsentPrompt != null, MaximumCookieConsentWaitTime);
            Assert.NotNull(Page.CookieConsentPrompt);
            Assert.True(Page.CookieConsentPrompt.Displayed);
        }

        [Then(@"I go again to the (.*) page")]
        public void ThenIGoAgainToThePage(string page)
        {
            AppBrowser.NavigateToPage(page);
        }

        [Then(@"No cookie prompt is displayed")]
        public void ThenNoCookiePromptIsDisplayed()
        {
            AutomationHelper.Wait(MaximumCookieConsentWaitTime); // should not be displayed within the given timeout
            Assert.IsTrue(Page.CookieConsentPrompt == null || !Page.CookieConsentPrompt.Displayed);
        }

        [When(@"I accept all cookies")]
        public void WhenIAcceptAllCookies()
        {
            Page.AcceptAllCookies();
        }

        [When(@"I click accept social cookies selector")]
        public void WhenIClickAcceptSocialCookiesSelector()
        {
            Page.ClickAcceptSocialCookies();
        }

        [Given(@"Cookie consent is enabled and configured for (.*)")]
        public void GivenCookieConsentIsEnabledAndConfigured(string page)
        {
            //TODO: home page setting and configuration
            //CookieConfigurationRoot - test page - will be created automaticly in future 43295

            var cookieLevelOneSettings = new Dictionary<string, string> { { "CookieList", "base_cookie" }, { "Description", "Base Level" }};
            var cookieLevelOnePage = CmsHelper.PrepareSandboxTestPage(
                AppBrowser.BaseUrl,
                SandboxEnum.BRI,
                "/Cookie-Levels/Base-level/",
                "[BRI Data] Cookie Level Item",
                cookieLevelOneSettings);

            var cookieLevelTwoSettings = new Dictionary<string, string> { { "CookieList", "extended_cookie" }, { "Description", "Extended Level" }, { "Features", "ga,survey,marketing-overlay,legal-challenge,social-sharing,outdated-browser-warning,mobile-view" }};
            var cookieLevelTwoPage = CmsHelper.PrepareSandboxTestPage(
                AppBrowser.BaseUrl,
                SandboxEnum.BRI,
                "/Cookie-Levels/Extended-level/",
                "[BRI Data] Cookie Level Item",
                cookieLevelTwoSettings);
            
            var homePageSettingsDict = new Dictionary<string, string>
                                       {
                                           {"CookieConfigurationRoot", cookieLevelOnePage.ParentID.ToString(System.Globalization.CultureInfo.InvariantCulture) },
                                           {"CookieConsentPromptConfigureLinkText", "Configure cookies"},
                                           {"CookieConsentSettingsHeading", "Configure"},
                                           {"CookieConsentPromptAcceptButtonText", "Accept all cookies"},
                                           {"CookieConsentSettingsContent", "<p>By continuing to visit aegon.com you will be agreeing to our <a href=\"/Templates/GenericContentpage.aspx?id=27877\">Disclaimer</a>, <a href=\"/Documents/aegon-com/Sitewide/Ad-hoc-documents/General-terms-and-conditions.pdf\">General terms and conditions</a>, the <a href=\"/Templates/GenericContentpage.aspx?id=27881\">Privacy statement</a> and <a href=\"/Templates/GenericContentpage.aspx?id=27885\">Use of cookies</a> while you are on the website.</p> <p>By continuing to visit aegon.com you will be agreeing to our Disclaimer, General terms and conditions, the Privacy statement and Use of cookies while you are on the website.</p>	LongString"},
                                           {"CookieConsentSettingsSaveButtonText", "Save configuration"},
                                           {"CookieConsentSettingsReadMoreText", "Read more about cookies"},
                                           {"CookieConsentSettingsReadMoreLink", "http://en.wikipedia.org/wiki/HTTP_cookie"},
                                           {"CookieConsentPromptHeading", "A note to our visitors. A note to our visitors. A note to our visitors"}
                                       };

            CmsHelper.EditSandboxHomePage(
                AppBrowser.BaseUrl,
                SandboxEnum.BRI,
                page,
                "[BRI Templates] Homepage",
                homePageSettingsDict);
        }

        [Given(@"Cookie consent is disabled for (.*)")]
        public void GivenCookieConsentIsDisabled(string page)
        {
            var homePageSettingsDict = new Dictionary<string, string> { { "CookieConfigurationRoot", string.Empty }, };

            CmsHelper.EditSandboxHomePage(
                AppBrowser.BaseUrl,
                SandboxEnum.BRI,
                page,
                "[BRI Templates] Homepage",
                homePageSettingsDict);
        }
    }
}
