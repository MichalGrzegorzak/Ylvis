using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aegon.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Aegon.Page
{
    public class BriOverviewPage : BriPage
    {
        [FindsBy(How = How.CssSelector, Using = ".overviewpage-section")]
        private IList<IWebElement> _sectionElements = null;
        public IList<IWebElement> SectionElements { get { return _sectionElements; } }

        [FindsBy(How = How.CssSelector, Using = ".section-header")]
        private IList<IWebElement> _sectionTitles = null;
        public IList<IWebElement> SectionTitles { get { return _sectionTitles; } }

        [FindsBy(How = How.CssSelector, Using = ".aeg-overview-pager")]
        private IList<IWebElement> _pagers = null;
        public IList<IWebElement> Pagers { get { return _pagers.Where(x => x.GetElementSafe() != null).ToList(); } }

        [FindsBy(How = How.CssSelector, Using = ".pager")]
        private IWebElement _pages = null;
        public IWebElement Pages { get { return _pages.GetElementSafe(); } }

        [FindsBy(How = How.CssSelector, Using = "li.aeg-current-page > span")]
        private IList<IWebElement> _currentPageNumber = null;
        public IList<IWebElement> CurrentPageNumber { get { return _currentPageNumber.Where(x => x.GetElementSafe() != null).ToList(); } }

        [FindsBy(How = How.CssSelector, Using = ".overview-section-filter-container .linklist-dropdown .ui-corner-bottom a")]
        private IList<IWebElement> _filters = null;
        public IList<IWebElement> Filters { get { return _filters.Where(x => x.GetElementSafe() != null).ToList(); } }

        [FindsBy(How = How.CssSelector, Using = "a.ui-selectmenu.js-open-dropdown")]
        private IWebElement _filterDropDownButton = null;
        public IWebElement FilterDropDownButton { get { return _filterDropDownButton.GetElementSafe(); } }

        [FindsBy(How = How.CssSelector, Using = ".overview-section-filter-container")]
        private IWebElement _filterContainer = null;
        public IWebElement FilterContainer { get { return _filterContainer.GetElementSafe(); } }

        [FindsBy(How = How.CssSelector, Using = ".aeg-overview-pager a.ui-selectmenu.js-open-dropdown")]
        private IWebElement _pageSizeDropDownButton = null;
        public IWebElement PageSizeDropDownButton { get { return _pageSizeDropDownButton.GetElementSafe(); } }

        [FindsBy(How = How.CssSelector, Using = ".aeg-overview-pager .linklist-dropdown .ui-corner-bottom a")]
        private IList<IWebElement> _pageSizes = null;
        public IList<IWebElement> PageSizes { get { return _pageSizes.Where(x => x.GetElementSafe() != null).ToList(); } }
        
        public IEnumerable<string> GetSectionTitlesTexts()
        {
            foreach (var sectionTitle in SectionTitles)
            {
                yield return sectionTitle.Text;
            }
        }

        public bool IsPagerEmpty()
        {
            return Pages.FindElementSafe(By.CssSelector(".aeg-pagination")) == null;
        }

        public int? GetCurrentPageNumber()
        {
            WebElementExtensions.WaitForElement(Driver, TimeSpan.FromSeconds(2),
                                                By.CssSelector("li.aeg-current-page > span"));
            var span = CurrentPageNumber.FirstOrDefault();
            if(span != null)
            {
                int pageNumber;
                if (int.TryParse(span.Text, out pageNumber))
                {
                    return pageNumber;
                }
                else
                {
                    Console.WriteLine(string.Format("Cannot parse oage number {0}", span.Text));
                }
            }
            else
            {
                Console.WriteLine("Span is null");
            }

            return null;
        }

        public IWebElement GetSection(string sectionTitle)
        {
            return SectionElements.FirstOrDefault(x => x.FindElement(By.CssSelector(".section-header")).Text == sectionTitle);
        }

        public bool IsSecionEmpty(IWebElement section)
        {
            var sectionItem = section.FindElement(By.CssSelector(".section-item"));
            if(sectionItem != null)
            {
                return sectionItem.FindElement(By.CssSelector(".item-header")) == null;
            }
            else
            {
                return true;
            }
        }

        public bool IsContaningAllCssElements(IWebElement section, string[] cssClasses)
        {
            foreach (var cssClass in cssClasses)
            {
                foreach (var item in section.FindElements((By.CssSelector(".section-item"))))
                {
                    if (item.FindElementSafe(By.ClassName(cssClass)) == null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void OpenDropDown()
        {
            FilterDropDownButton.Click();
        }

        public void SelectFilter(string filterName)
        {
            var filter = Filters.FirstOrDefault(x => x.Text == filterName);
            filter.ClickAndWaitForPageToLoad(Driver);
        }

       
        public IEnumerable<string> GetFirstLevelFilters()
        {
            return FilterContainer.FindElements(By.CssSelector(".ui-corner-bottom li a")).Select(x => x.Text);
        }

        public void OpenPageSizeDropDown()
        {
            PageSizeDropDownButton.Click();
        }

        public void SelectPageSize(string size)
        {
            var item = PageSizes.FirstOrDefault(x => x.Text == size);
            item.ClickAndWaitForPageToLoad(Driver);
        }
    }
}
