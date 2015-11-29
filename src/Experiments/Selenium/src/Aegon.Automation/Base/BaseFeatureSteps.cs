using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Threading;
using Aegon.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Aegon.Extensions;
using Aegon.Helpers;

namespace Aegon.Base
{
    [Binding]
    public class BaseFeatureSteps
    {
        public const string BrowserKey = "__Browser__";

        public static WebBrowser AppBrowser
        {
            get
            {
                if (!FeatureContext.Current.ContainsKey(BrowserKey))
                {
                    var bs = new WebBrowser();
                    FeatureContext.Current.Add(BrowserKey, bs);
                }

                return FeatureContext.Current.Get<WebBrowser>(BrowserKey);
            }
        }

        private BasePage _currentPage;
        public BasePage CurrentPage
        {
            get
            {
                if (_currentPage != null)
                    _currentPage.Initialize(AppBrowser.WebDriver);

                return _currentPage;
            }
            
            set { _currentPage = value; }
        }

        [BeforeFeature]
        private static void BeforeFeature()
        {
            AppBrowser.Configure(new SandboxEnvironment());
        }

        [AfterFeature]
        private static void AfterFeature()
        {
            AppBrowser.Quit();
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            AppBrowser.DeleteAllCookies();
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            bool showUrl = true; //TODO: Read from config
            //if (ScenarioContext.Current.TestError != null)
            {
                // generate a file name and location
                var screenshotFileName = FeatureContext.Current.FeatureInfo.Title;
                screenshotFileName = screenshotFileName + DateTime.Now;
                screenshotFileName = screenshotFileName.Replace(' ', '/').Replace('/', '-').Replace(':', '-') + ".png";                
                var screenshotFullFileName = Path.Combine(AppBrowser.GetScreenshotFolder(), screenshotFileName);
                
                //take screenshot
                AppBrowser.TakeScreenshot(screenshotFullFileName);

                // display the sceenshot file location for reporting                
                var screenshootUrl = Path.Combine(ConfigurationManager.AppSettings["OutputFolderUrl"], screenshotFileName);
                Console.WriteLine("Screenshot : {0} ", screenshootUrl);
                showUrl = true; //TODO: read from config
            }

            //display browser URL
            if (showUrl)
            {
                Console.WriteLine("URL: {0}", AppBrowser.WebDriver.Url);
            }
        }

        [Given(@"I am on the (.*) site")]
        public static void GivenIAmOnTheSite(string siteKey)
        {
            AppBrowser.SetBaseUrl(siteKey);
            //AppBrowser.NavigateToBasePage(); //AppBrowser.NavigateToBasePage(); - not needed, will be called inside SignIn method
            AppBrowser.SandboxEnvironment.SignIn(AppBrowser);
        }

        [When(@"I go to the (.*) page")]
        public static void WhenIGoToThePage(string page)
        {
            AppBrowser.NavigateToPage(page);
        }

        [When(@"I click link by (.*) selector")]
        public static void WhenIClickLinkBySelector(string linkSelector)
        {
            var link = AppBrowser.FindElementSafe(By.CssSelector(linkSelector));
            Assert.NotNull(link, "Could not find a link to click on.");
            AppBrowser.ExecuteScript(string.Format("window.scrollTo(0,{0});", link.Location.Y));
            AutomationHelper.Wait(link.ClickSafe, TimeSpan.FromSeconds(10));
        }

        [When(@"I click link by (.*) id")]
        public static void WhenIClickLinkById(string linkId)
        {
            var link = AppBrowser.FindElementSafe(By.Id(linkId));
            Assert.NotNull(link, "Could not find a link to click on.");
            AppBrowser.ExecuteScript(string.Format("window.scrollTo(0,{0});", link.Location.Y));
            AutomationHelper.Wait(link.ClickSafe, TimeSpan.FromSeconds(10));
        }

        [When(@"I enter (.*) into (.*)")]
        public static void WhenIEnterInto(string text, string inputId)
        {
            var input = AppBrowser.FindElementSafe(By.Id(inputId));
            Assert.NotNull(input, "Could not find an input to enter text into.");
            input.SendKeys(text);
        }

        [When(@"I wait ([\d]+) milliseconds")]
        public static void WhenIWaitNMilliseconds(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        [Given(@"I turned (.*) ErrorPage checking")]
        public static void GivenITurnedOnOffErrorPageChecking(string checkErrorPage)
        {
            AppBrowser.IgnoreErrorPages = checkErrorPage != "on";
        }

        [Given(@"I (.*) page redirections")]
        public static void WhenIIgnorePageRedirections(string behavior)
        {
            foreach (RedirectBehavior e in Enum.GetValues(typeof (RedirectBehavior)))
            {
                if (behavior.ToLowerInvariant().StartsWith(e.ToString().ToLowerInvariant()))
                {
                    AppBrowser.RedirectBehavior = e;
                    return;
                }
            }
            AppBrowser.RedirectBehavior = RedirectBehavior.Pending; // default
        }

        [Given(@"On the (.*) homepage I set the value of (.*) to (.*)")]
        public static void GivenOnTheHomepageISetTheValueOfProperty(string siteKey, string property, string propertyValue)
        {
            // TODO: Find proper homepage

            var homePageSettingsDict = new Dictionary<string, string> { { property, propertyValue } };
                Helpers.CmsHelper.EditSandboxHomePage(
                AppBrowser.BaseUrl,
                TestAutomationReference.SandboxEnum.BRI,
                siteKey,
                "[BRI Templates] Homepage",
                homePageSettingsDict);
        }


        [Given(@"On (.*) (.*) I set the value of (.*) property to (.*)")]
        public static void GivenOnThePageISetTheValueOfProperty(string siteKey, string pageKey, string property, string propertyValue)
        {
            var properties = new Dictionary<string, string> { { property, propertyValue } };

            CmsHelper.PrepareSandboxTestPage(
                AppBrowser.BaseUrl,
                TestAutomationReference.SandboxEnum.BRI,
                pageKey,
                "*",
                properties);
        }

        [When(@"I set (\d+) Cookie Consent level")]
        public static void WhenISetCookieConsentLevel(int level)
        {
            var script = String.Format(
                "var newLevel = POSSIBLE.CookieFilter.getInstance().setCurrentLevel({0});" +
                "jQuery(document).trigger('cookie-level-changed');" +
                "return newLevel.toString();", level);
            Assert.AreEqual(level.ToString(CultureInfo.InvariantCulture), AppBrowser.ExecuteScript<string>(script));
        }

        [Then(@"Nevermind")]
        public static void Nevermind()
        {
            Assert.True(true);
        }
    }
}
