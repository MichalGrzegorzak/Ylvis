using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Imaging;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Aegon.Base
{

    public abstract class Base
    {
        protected static string BaseUrl;
        protected static string ContactUsPageUrl;
        protected static string SearchResultPageUrl;
        protected static string CustomErrorPageUrl;
        protected static string QuarterlyResultsPageUrl;
        protected static string OfficeOverviewPageUrl;
        protected static string ContactUsFormPageUrl;
        protected static string GlossaryPageUrl;

        protected static string RoBriHomePageUrl;
        protected static string BriLandingPageUrl;
        protected static string SectionPageUrl;

        protected static string FundOverViewPageUrl;

        public StringBuilder VerificationErrors;

        public static IWebDriver Driver;

        public static string BrowserSelection = "Firefox";

        protected static IWebDriver SetDriver()
        {
            string browser = ConfigurationManager.AppSettings["browser"];

            if (browser.ToLower() == "firefox")
                Driver = new FirefoxDriver();

            else if (browser.ToLower() == "chrome")
                Driver = new ChromeDriver();

            else if (browser.ToLower() == "ie" || browser.ToLower() == "internet explorer" || browser.ToLower() == "internetexplorer")
                Driver = new InternetExplorerDriver();

            return Driver;
        }

        //protected static void SetUrls(string site)
        //{
            //site = site.ToLower();

            //if (site.Contains("pl"))
            //{
            //    BaseUrl = EnvironmentUrl.AegonPl;
            //    ContactUsPageUrl = EnvironmentUrl.AegonPl + "/pl/Strona-glowna/Kontakt/";
            //    SearchResultPageUrl = EnvironmentUrl.AegonPl + "/pl/Strona-glowna/SearchResults/";
            //    CustomErrorPageUrl = EnvironmentUrl.AegonPl + "/some-ramdom-url/";
            //}

            //else if (site.Contains("cz"))
            //{
            //    BaseUrl = EnvironmentUrl.AegonCz;
            //    ContactUsPageUrl = EnvironmentUrl.AegonCz + "/cs/Domu/Kontaktujte-nas/";
            //    SearchResultPageUrl = EnvironmentUrl.AegonCz + "/cs/Domu/Vysledky-vyhledavani/";
            //    CustomErrorPageUrl = EnvironmentUrl.AegonCz + "/some-ramdom-url/";
            //}

            //else
            //{
            //    BaseUrl = EnvironmentUrl.AegonCom;
            //    ContactUsPageUrl = EnvironmentUrl.AegonCom + "/en/Home/About/Contact-Us/";
            //    SearchResultPageUrl = EnvironmentUrl.AegonCom + "/en/Home/About/---/SearchResults/";
            //    CustomErrorPageUrl = EnvironmentUrl.AegonCom + "/some-ramdom-url/";
            //}


        //}

        protected static IWebDriver GetDriver()
        {
            return Driver;
        }

        protected string GetElementIdentifier(string element)
        {
            return (element = ConfigurationManager.AppSettings[element]);
        }

        protected string GetKeyValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        protected bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected bool IsElementNotPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return false;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }

        protected IList<IWebElement> ListOfElements(By by)
        {
            // List count return total number of element
            IList<IWebElement> elementList = Driver.FindElements(by);
            return elementList;
        }

        protected static void SignInToEnvironment()
        {
            var username = ConfigurationManager.AppSettings["UserName"].ToLower();
            if (!String.IsNullOrEmpty(username))
            {
                var password = ConfigurationManager.AppSettings["Password"].ToLower();

                Driver.Navigate().GoToUrl(BaseUrl);

                Driver.FindElement(By.Id("ctl00_FullRegion_LoginControl_UserName")).Clear();
                Driver.FindElement(By.Id("ctl00_FullRegion_LoginControl_UserName")).SendKeys(username);
                Driver.FindElement(By.Id("ctl00_FullRegion_LoginControl_Password")).Clear();
                Driver.FindElement(By.Id("ctl00_FullRegion_LoginControl_Password")).SendKeys(password);
                Driver.FindElement(By.Id("ctl00_FullRegion_LoginControl_Button1")).Click();
            }
        }

        protected void OpenPage(string pageUrl)
        {
            //string url = EnvironmentUrl.AegonCom + GetKeyValue(pageUrl);
            //Driver.Navigate().GoToUrl(url);
        }

        //protected void NavigateTo(string url)
        //{
        //    driver.Navigate().GoToUrl(base + url);
        //}

        protected IWebElement FindElementInMaxTenSec(By by)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 10) Assert.Fail(by + "  - Element not found in 10 Seconds! May be the element doens't exist or the page is taking too long to load");
                try
                {
                    if (Driver.FindElement(by).Displayed)
                        return Driver.FindElement(by);
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }

        protected IWebElement FindElement(By by)
        {
            return Driver.FindElement(by);
        }

        protected void AssertTitle(string title)
        {
            Assert.AreEqual(title, Driver.Title);
        }

        protected void AssertTitleContains(string title)
        {
            Assert.IsTrue(Driver.Title.ToLower().Contains(title.ToLower())); 
        }

        protected void AssertElementPresent(By by)
        {
            Assert.IsTrue(IsElementPresent(by));
        }

        protected void AssertElementDisplayed(By by)
        {
            Assert.IsTrue(FindElement(by).Displayed);
        }



        protected void AssertElementNotPresent(By by)
        {
            Assert.IsFalse(IsElementPresent(by));
        }

        protected void Type(By by, string text)
        {
            try
            {
                FindElementInMaxTenSec(by).SendKeys(text);
            }
            catch (AssertionException e)
            {
                VerificationErrors.Append(e.Message);
            }
        }

        protected void Click(By by)
        {
            FindElementInMaxTenSec(by).Click();
        }

        protected void ClickElement(By by)
        {
            FindElement(by).Click();
        }

        protected void VerifyText(By by, string text)
        {
            try
            {
                Assert.AreEqual(text, FindElementInMaxTenSec(by).Text);
            }
            catch (AssertionException e)
            {
                VerificationErrors.Append(e.Message);
            }

        }

        protected string RandomString(int charsInString)
        {
            var random = new Random();

            // Create a string to contain all valid characters (in this case, just letters)
            const string all = "qwertyuiopasdfghjklzxcvbnm";

            // Create a variable that will be returned, it will hold the random string
            string returnMe = "";

            // Run for loop until we have reached the desired number of Chars_In_String
            for (int i = 0; i < charsInString; i++)
            {
                // Each time through, add to ReturnMe (selecting a random character out of the string of all valid characters)
                returnMe += all[random.Next(0, all.Length)];

            }

            // Return the value of ReturnMe
            return returnMe;
        }

        protected void WaitForElementPresent(By by)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("Element Not Present!");
                try
                {
                    if (IsElementPresent(by)) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }

        protected void WaitForEitherElementPresent(By by1, By by2)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(by1)) break;
                    if (IsElementPresent(by2)) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }

        protected void WaitForVisible(By by)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("Element Not Visible!");
                try
                {
                    if (Driver.FindElement(by).Displayed) break;

                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }


        // The element  be present for this to work 
        protected void ClickWhenClickable(By by)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(by))
                        Driver.FindElement(by).Click();

                    else
                        break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }

        protected void WaitForTitle(String title)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (title == Driver.Title) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }


        protected void WaitForText(By by, string text)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (text == Driver.FindElement(by).Text) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }

        protected static void TakeScreenshot(string saveLocation)
        {
            //take a screenshot and save it
            var screenshotDriver = Driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(saveLocation, ImageFormat.Png);
        }


    }
}