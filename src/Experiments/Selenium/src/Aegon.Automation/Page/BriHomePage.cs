using System.Collections.Generic;
using Aegon.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Aegon.Page
{
    public class BriHomePage : BriPage
    {
        #region Page elements

        [FindsBy(How = How.CssSelector, Using = "#footer .aeg-quick-nav li a")]
        public IList<IWebElement> FooterLinksElements { get; set; }

        #endregion
    }
}
