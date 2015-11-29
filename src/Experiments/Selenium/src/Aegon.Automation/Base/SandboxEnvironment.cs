using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using Aegon.Extensions;
using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace Aegon.Base
{
    public class SandboxEnvironment : ISandboxEnvironment
    {
        public string Browser { get; set; }
        public bool UseEmbededChrome { get; set; }
        
        public IDictionary<string, string> BaseUrls { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string ExtensionsBasePath { get; set; }
        public string LocalExtensionsNames { get; set; }
        public int PageLoadTimeout { get; set; }

        public SandboxEnvironment()
        {
            SetupBrowser();
            SetupUrls();
            SetupUser();
        }

        private void SetupBrowser()
        {
            ExtensionsBasePath = ConfigurationManager.AppSettings["ExtensionsBasePath"].ToLower();
            LocalExtensionsNames = ConfigurationManager.AppSettings["LocalExtensionsNames"].ToLower();
            Browser = ConfigurationManager.AppSettings["browser"].ToLower();
            UseEmbededChrome = bool.Parse(ConfigurationManager.AppSettings["UseEmbededChrome"].ToLower());
            PageLoadTimeout = int.Parse(ConfigurationManager.AppSettings["PageLoadTimeout"]);
        }

        public virtual bool SignIn(WebBrowser browser)
        {
            int retryCount = 3;
            for (int i = 0; i < retryCount; i++)
            {
                bool signInResult = InternalSignIn(browser);                
                if(signInResult)
                    return true;                
            }
            return false;
        }

        private bool InternalSignIn(WebBrowser browser)
        {
            browser.NavigateToBasePage();
            if (!String.IsNullOrEmpty(UserLogin))
            {
                WebElementExtensions.WaitForElement(
                    browser.WebDriver,
                    TimeSpan.FromSeconds(5),
                    By.Id("ctl00_FullRegion_LoginControl_UserName"));

                var userNameElement = browser.FindElementSafe(By.Id("ctl00_FullRegion_LoginControl_UserName"));
                if (userNameElement == null || !userNameElement.Displayed)
                {
                    Console.WriteLine("Login control not found");                    
                    Console.WriteLine("URL: {0} ", browser.WebDriver.Url);                    
                    return false;
                }
                
                browser.WebDriver.FindElement(By.Id("ctl00_FullRegion_LoginControl_UserName")).Clear();
                browser.WebDriver.FindElement(By.Id("ctl00_FullRegion_LoginControl_UserName")).SendKeys(UserLogin);
                browser.WebDriver.FindElement(By.Id("ctl00_FullRegion_LoginControl_Password")).Clear();
                browser.WebDriver.FindElement(By.Id("ctl00_FullRegion_LoginControl_Password")).SendKeys(UserPassword);
                browser.WebDriver.FindElement(By.Id("ctl00_FullRegion_LoginControl_Button1")).ClickAndWaitForPageToLoad(browser.WebDriver);
                
                //wait for serwer response
                var cookieName = browser.WebDriver.Manage().Cookies.GetCookieNamed(".EPiServerLogin");
                int loginWaitCount = 10;
                while(cookieName == null)
                {
                    Console.WriteLine("Auth cookie not found, retry ");
                    if(loginWaitCount <= 0)
                        break;                    
                    loginWaitCount--;
                    Thread.Sleep(250); //TODO: read from configuration
                    cookieName = browser.WebDriver.Manage().Cookies.GetCookieNamed(".EPiServerLogin");
                }

                return cookieName != null;
            }
            return true;
        }

        private void SetupUrls()
        {
            var urls = ConfigurationManager.AppSettings["BaseUrls"]
                .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new { Items = x.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries) });

            BaseUrls = urls.ToDictionary(k => k.Items[0].ToLowerInvariant(), v => v.Items[1]);
        }

        private void SetupUser()
        {
            UserLogin = ConfigurationManager.AppSettings["UserLogin"];
            UserPassword = ConfigurationManager.AppSettings["UserPassword"];
        }
    }
}