using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using Aegon.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;

using TechTalk.SpecFlow;

namespace Aegon.Base
{

    public class ScreenShotRemoteWebDriver : RemoteWebDriver, ITakesScreenshot
    {
        public ScreenShotRemoteWebDriver(Uri uri, DesiredCapabilities dc)
            : base(uri, dc)
        {
        }

        public Screenshot GetScreenshot()
        {
            Response screenshotResponse = this.Execute(DriverCommand.Screenshot, null);
            string base64 = screenshotResponse.Value.ToString();
            return new Screenshot(base64);
        }
    }
    
    public class WebBrowser
    {
        public ISandboxEnvironment SandboxEnvironment { get; private set; }
        public IWebDriver WebDriver { get; private set; }
        public string BaseUrl { get; set; }
        public bool IgnoreErrorPages { get; set; }
        public RedirectBehavior RedirectBehavior { get; set; }

        private Dictionary<string, List<string>> BrowserExtensions { get; set; }
        private List<string> errorPageUrls;

        public IJavaScriptExecutor JavaScriptExecutor
        {
            get { return WebDriver as IJavaScriptExecutor; }
        }

        public void Configure(ISandboxEnvironment environment)
        {
            SandboxEnvironment = environment;
            SetupBrowserExtensions(environment);
            SetupWebDriver(environment);
            SetDefaultBaseUrl();
            IgnoreErrorPages = false;
            RedirectBehavior = RedirectBehavior.Pending;
        }

        private void SetupBrowserExtensions(ISandboxEnvironment environment)
        {
            BrowserExtensions = new Dictionary<string, List<string>>();
            if (!string.IsNullOrWhiteSpace(environment.LocalExtensionsNames))
            {
                foreach (var browserExtension in environment.LocalExtensionsNames.Split(new char[]{','}))
                {
                    var splited = browserExtension.Split(new char[] { ':' });
                    string browserName = splited[0];
                    string extensionName = splited[1];
                    if (!BrowserExtensions.ContainsKey(browserName))
                    {
                        BrowserExtensions.Add(browserName, new List<string>() { Path.Combine(environment.ExtensionsBasePath, extensionName)});
                    }
                    else
                    {
                        BrowserExtensions[browserName].Add(Path.Combine(environment.ExtensionsBasePath, extensionName));
                    }
                }
            }
        }

        public void DeleteAllCookies()
        {
            var cookiesManager = WebDriver.Manage().Cookies;            
            if (cookiesManager != null)
            {
                cookiesManager.DeleteAllCookies();
            }
        }

        public void Quit()
        {
            WebDriver.Quit();
        }

        private void SetupWebDriver(ISandboxEnvironment config)
        {
            switch (config.Browser)
            {
                case "sauce":
                    DesiredCapabilities capabillities = DesiredCapabilities.Firefox();
                    capabillities.SetCapability(CapabilityType.Version, "10");
                    capabillities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.XP));
                    capabillities.SetCapability("name", "Testing Selenium 2 with C# on Sauce");
                    capabillities.SetCapability("username", "aegon_possiblepoland");
                    capabillities.SetCapability("accessKey", "94b8db59-2d40-49af-9f58-0c3a878ef91d");      
                    WebDriver = new ScreenShotRemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), capabillities);

                    break;
                    
                case "browserstack":
                    
                    DesiredCapabilities capability = DesiredCapabilities.Firefox();
                    capability.SetCapability("browserstack.user", "andrzejkwiecie");
                    capability.SetCapability("browserstack.key", "qstqybs8si11BQsgNC4u");
                    capability.SetCapability("browserstack.debug", "true");

                    capability.SetCapability("browser", "IE");
                    capability.SetCapability("browser_version", "6.0");
                    capability.SetCapability("os", "Windows");
                    capability.SetCapability("os_version", "XP");
                    capability.SetCapability("resolution", "800x600");

                    WebDriver = new ScreenShotRemoteWebDriver(new Uri("http://hub.browserstack.com/wd/hub/"), capability);

                    break;                    
                case "firefox":

                    FirefoxProfile ffProfile = new FirefoxProfile();

                    if (BrowserExtensions.ContainsKey(config.Browser))
                    {
                        foreach (var browserExtension in BrowserExtensions[config.Browser])
                        {
                            ffProfile.AddExtension(browserExtension);                            
                        }
                        
                        //steup YSlow Extensions
                        //simple version - harlog.ex must be configured
                        //yslow requrie firbug enabled
                        /*
                        ffProfile.SetPreference("extensions.yslow.beaconUrl", @"http://localhost:9090/");
                        ffProfile.SetPreference("extensions.yslow.beaconInfo", "basic");
                        ffProfile.SetPreference("extensions.yslow.optinBeacon", true);
                        ffProfile.SetPreference("extensions.yslow.autorun", true);

                        
                        ffProfile.SetPreference("extensions.firebug.firebug", "1.12.6");
                        ffProfile.SetPreference("extensions.firebug.allPagesActivation", "on");
                         */
                        //ffProfile.SetPreference("extensions.firebug.autorun", true);
                        //ffProfile.SetPreference("extensions.firebug.autorun", true);

                    }

                    WebDriver = new FirefoxDriver(ffProfile);
                    break;

                case "chrome":

                    //http://chromedriver.storage.googleapis.com/index.html?path=2.8/ - chrome driver source
                    ChromeOptions options = new ChromeOptions();

                    if (BrowserExtensions.ContainsKey(config.Browser))
                    {
                        foreach (var browserExtension in BrowserExtensions[config.Browser])
                        {
                            options.AddExtension(browserExtension);
                        }
                    }

                    if(config.UseEmbededChrome)
                        options.BinaryLocation = config.ExtensionsBasePath + @"\chromedriver.exe";
                    
                    WebDriver = new ChromeDriver(config.ExtensionsBasePath, options);
                    break;

                case "ie":
                case "internet explorer":
                case "internetexplorer":
                default:
                    //ie driver path: http://code.google.com/p/selenium/downloads/list
                    WebDriver = new InternetExplorerDriver(config.ExtensionsBasePath);
                    break;
            }

            // additional configuration
            if (WebDriver != null && config.Browser != "sauce") //for some reason, WebDriver.Manage() throws excetpion, when using RemoteWebDriver and SauceLabs hub
            {                
                WebDriver.Manage().Window.Maximize();
                WebDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(config.PageLoadTimeout));
            }
        }

        public void SetDefaultBaseUrl()
        {
            BaseUrl = SandboxEnvironment.BaseUrls.First().Value;
        }

        public void SetBaseUrl(string urlKey)
        {
            urlKey = (urlKey ?? string.Empty).ToLowerInvariant();
            if (SandboxEnvironment.BaseUrls.ContainsKey(urlKey))
                BaseUrl = SandboxEnvironment.BaseUrls[urlKey];
        }

        public void NavigateToBasePage()
        {
            WebDriver.Navigate().GoToUrl(BaseUrl);
            PerformPageValidations(BaseUrl);
        }

        public void NavigateToPage(string page)
        {
            int retryCount = 1;
            for (int i = 0; i < retryCount; i++)
            {
                bool signInResult = InternalNavigateToPage(page);
                if (signInResult)
                    break;
            }
            
            //Ignore tests, if test page is not accesible (eg. gallery pages not working, because redirect to new BRI overvie page)           
            if (WebDriver.Url != BaseUrl + page)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Test case execution stopped because of incorect URL, probably redirect to another page is set");
                sb.AppendLine("Expected URL: " + BaseUrl + page);
                sb.AppendLine("Current URL: " + WebDriver.Url);
                var msg = sb.ToString();
                switch (RedirectBehavior)
                {
                    case RedirectBehavior.Fail:
                        Console.WriteLine(msg);
                        Assert.Fail(msg);
                        break;
                    case RedirectBehavior.Pass:
                        Assert.Pass();
                        break;
                    case RedirectBehavior.Ignore:
                        break;
                    case RedirectBehavior.Warn:
                        Console.WriteLine(msg);
                        break;
                    default:
                        Console.WriteLine(msg);
                        ScenarioContext.Current.Pending();
                        break;
                }
            }
        }

        private bool InternalNavigateToPage(string page)
        {
            WebDriver.Navigate().GoToUrl(BaseUrl + page);
            return PerformPageValidations(page);
        }

        private bool PerformPageValidations(string page)
        {
            if (!IgnoreErrorPages)
            {
                if (IsErrorPage(page))
                {
                    Assert.Fail("Error page, during navigationg to:" + page);
                }
            }

            return WebElementExtensions.WaitForElement(
                    WebDriver,
                    TimeSpan.FromSeconds(5),
                    By.CssSelector("html.js"));
        }

        private bool IsErrorPage(string page)
        {
            return WebDriver.PageSource.Contains("<!-- automation-tag:error -->");
        }

        public void SetupErrorPagesUrls(IEnumerable<string> urlList)
        {
            errorPageUrls = new List<string>();
            errorPageUrls.AddRange(urlList);
        }

        public void TakeScreenshot(string screenShotName)
        {
            //take a screenshot and save it
            var screenshotDriver = WebDriver as ITakesScreenshot;
            if (screenshotDriver != null)
            {
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile(screenShotName, ImageFormat.Png);
            }
        }

        public string GetScreenshotFolder()
        {
            var path = Path.Combine(ConfigurationManager.AppSettings["OutputFolder"], "Screenshots");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public void SendKeys(string keys)
        {
            var actions = new Actions(WebDriver);
            actions.SendKeys(keys).Build().Perform();
        }

        public void ExecuteScript(string script)
        {
            JavaScriptExecutor.ExecuteScript(script);
        }

        public T ExecuteScript<T>(string script)
        {
            return WebDriver.ExecuteJavaScript<T>(script);
        }

        public IWebElement FindElementSafe(By selector)
        {
            IWebElement element = null;

            try
            {
                element = WebDriver.FindElement(selector);
            }
            catch
            {
                return null;
            }

            return element;
        }
    }
}
