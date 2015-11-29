using System.Collections.Generic;
using System.Linq;
using Aegon.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Aegon.Page
{
    public class MasterPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "ctl00_PageHeader_Search")]
        private IWebElement _topSearchTextboxLocator;
        public IWebElement TopSearchTextboxLocator { get { return _topSearchTextboxLocator.GetElementSafe(); } }

        [FindsBy(How = How.Id, Using = "ctl00_PageHeader_SubmitSearch")]
        public IWebElement TopSearchButtonLocator { get; set; }

        public SearchResultPage TopNavSearch(string keyword)
        {
            TopSearchTextboxLocator.SendKeys(keyword);
            TopSearchButtonLocator.Click();
            return new SearchResultPage();
        }

        [FindsBy(How = How.ClassName, Using = "padding")]
        private IWebElement _cookieWidgetLocator;
        public IWebElement CookieWidgetLocator {
            get { return _cookieWidgetLocator.GetElementSafe(); }
        }

        [FindsBy(How = How.Id, Using = "cboxOverlay")]
        private IWebElement _opalicityLayer;
        public IWebElement OpalicityLayer {
            get { return _opalicityLayer.GetElementSafe(); }
        }

        [FindsBy(How = How.Id, Using = "colorbox")]
        private IWebElement _opinionWidgetLocator;

        public IWebElement OpinionWidgetLocator {
            get { return _opinionWidgetLocator.GetElementSafe(); }
        }

        //public By CookieWidgetTitleLocator = By.CssSelector(".main-header");
        [FindsBy(How = How.CssSelector, Using = ".main-header")]
        private IWebElement _cookieWidgetTitleLocator;

        public IWebElement CookieWidgetTitleLocator {
            get { return _cookieWidgetTitleLocator.GetElementSafe(); }
        }

        [FindsBy(How = How.CssSelector, Using = ".close.btn")]
        private IWebElement _cookieWidgetIAgreeButton;

        public IWebElement CookieWidgetIAgreeButton {
            get { return _cookieWidgetIAgreeButton.GetElementSafe(); }
        }
        
        public By SurveyOverlayLocator = By.Id("cboxWrapper");
        public By SurveyOverlayTitleLocator = By.Id("cboxTitle");
        public By SurveyOverlayYesButton = By.CssSelector(".button-surv>span");
        public By SurveyOverlayNoButton = By.CssSelector(".survey-close>span");

        public By MessageOverlayLocator = By.Id("ctl00_MarketingOverlayControl_ContentDiv");

        //Footer and sitemap
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sitemap') and @rel='aeg-sitemap']")]
        private IWebElement _sitemapLinkIntheFooter;
        public IWebElement SitemapLinkIntheFooter {
            get { return _sitemapLinkIntheFooter.GetElementSafe(); }
        }

        [FindsBy(How = How.CssSelector, Using = ".aeg-sitemap>div")]
        private IList<IWebElement> _sitemapListLocator; 
        public IList<IWebElement> SitemapListLocator {
            get
            {
                var list = _sitemapListLocator.GetElementsSafe();
                return list != null ? list.ToList() : null;
            }
        }

        [FindsBy(How = How.CssSelector, Using = ".aeg-countries>.aeg-col")]
        private IList<IWebElement> _otherAegonSitesList; 
        public IList<IWebElement> OtherAegonSitesLists {
            get 
            { 
                var innerLists = _otherAegonSitesList.GetElementsSafe();
                return innerLists != null ? innerLists.ToList() : null;
            }
        }
            
        [FindsBy(How = How.CssSelector, Using = ".aeg-dropdown-link.aeg-dropdown-trigger>span")]
        private IWebElement _otherAegonSiteDropdownInFooter;
        public IWebElement OtherAegonSiteDropdownInFooter {
            get { return _otherAegonSiteDropdownInFooter.GetElementSafe(); }
        }

        [FindsBy(How = How.CssSelector, Using = "#ctl00_PageFooter_ctl00_GlobalSitesDiv>ul>li>a")]
        private IWebElement _globalSiteListInFooter;
        public IWebElement GlobalSiteListInFooter {
            get { return _globalSiteListInFooter.GetElementSafe(); }
        }

        [FindsBy(How = How.CssSelector, Using = "#ctl00_PageFooter_ctl00_CountrySitesDiv>ul>li>a")]
        private IWebElement _countrySiteListInFooter;
        public IWebElement CountrySiteListInFooter {
            get { return _countrySiteListInFooter.GetElementSafe(); }
        }

        [FindsBy(How = How.CssSelector, Using = ".global>li>a")]
        public IWebElement OtherSiteListInFooter { get; protected set; }
    }
}
