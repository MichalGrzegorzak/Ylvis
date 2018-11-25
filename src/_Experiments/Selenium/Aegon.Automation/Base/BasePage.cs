using Aegon.Extensions;
using Aegon.Helpers;
using System;
using System.Diagnostics;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Aegon.Page
{
    public class BasePage
    {
        #region Page elements

        [FindsBy(How = How.CssSelector, Using = "#divCookiePrompt a.close span")]
        private IWebElement _cookiePromptButtonElement = null;
        public IWebElement CookiePromptButtonElement { get { return _cookiePromptButtonElement.GetElementSafe(); } }

        [FindsBy(How = How.TagName, Using = "body")]
        private IWebElement _bodyElement = null;
        public IWebElement BodyElement { get { return _bodyElement.GetElementSafe(); } }

        [FindsBy(How = How.TagName, Using = "html")]
        private IWebElement _htmlElement = null;
        public IWebElement HtmlElement { get { return _bodyElement.GetElementSafe(); } }



        #endregion

        protected IWebDriver Driver { get; private set; }

        protected bool _isInitialized = false;

        public string Url
        {
            get { return Driver.Url; }
        }

        public string PageSource
        {
            get { return Driver.PageSource; }
        }

        private string _rawPageSource;
        public string RawPageSource
        {
            get
            {
                if (_rawPageSource == null)
                {
                    using (var wc = new WebClient())
                    {
                        wc.Headers.Add(HttpRequestHeader.Cookie, GetCookieContainer().GetCookieHeader(new Uri(Url)));
                        _rawPageSource = wc.DownloadString(Url);
                    }
                }
                return _rawPageSource;
            }
        }

        public virtual void Initialize(IWebDriver driver)
        {
            if (!_isInitialized)
            {
                Driver = driver;
                PageFactory.InitElements(driver, this);
                PageSetup();
                _isInitialized = true;
            }
        }

        public virtual void PageSetup()
        {
            CloseCookiePromptPopup();
            SetWindowFocus();
        }

        private void CloseCookiePromptPopup()
        {            
            if (CookiePromptButtonElement != null && CookiePromptButtonElement.Displayed)
            {
                AutomationHelper.WaitSeconds(3);
                CookiePromptButtonElement.ClickSafe();
                AutomationHelper.WaitSeconds(1);
            }
        }

        private void SetWindowFocus()
        {            
            BodyElement.SendKeys("\n"); //needed to re-set focus after click on cookie prompt
            //BodyElement.ClickSafe();  //this sometimes caused clicking on random elements
            /* Those methods also not working
            Driver.SwitchTo().Window(Driver.CurrentWindowHandle);
            return;
            IJavaScriptExecutor scriptExecutor = Driver as IJavaScriptExecutor;
            if (scriptExecutor != null)
            {
                scriptExecutor.ExecuteScript("this.focus();");
            }
             */
        }
        
        public IWebElement GetActiveElement()
        {
            return Driver.SwitchTo().ActiveElement();
        }

        protected IWebElement FindElement(By by)
        {
            return Driver.FindElement(by);
        }

        public CookieContainer GetCookieContainer()
        {
            var cookies = new CookieContainer();
            foreach (var cookie in Driver.Manage().Cookies.AllCookies)
            {
                cookies.Add(new System.Net.Cookie
                    {
                        Name = cookie.Name,
                        Path = cookie.Path,
                        Domain = cookie.Domain,
                        Expires = cookie.Expiry ?? DateTime.MaxValue,
                        Value = cookie.Value
                    });
            }
            return cookies;
        }
    }
}
