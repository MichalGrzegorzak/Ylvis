using System.Collections.Generic;
using System.Linq;
using Aegon.Extensions;
using Aegon.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Aegon.Page
{
    public class BriSidebarContentPage : BriPage
    {
        #region Page elements

        [FindsBy(How = How.CssSelector, Using = "#aeg-main .aeg-column-r")]
        private IWebElement _sidebarBlock = null;
        public IWebElement SidebarBlock
        {
            get { return _sidebarBlock.GetElementSafe(); }
        }

        public IEnumerable<IWebElement> SidebarModulesElements
        {
            get { return SidebarBlock.FindElementsSafe(By.CssSelector(".aeg-blocks .aeg-module")); }
        }

        public IList<BriModuleItem> SidebarModules
        {
            get
            {
                if (SidebarModulesElements == null)
                {
                    return new BriModuleItem[0];
                }

                return SidebarModulesElements
                    .Select(ObjectFactory.Create<BriModuleItem>)
                    .ToArray();
            }
        }

        #endregion
    }

    /// <summary>
    /// TODO: Fill properties
    /// </summary>
    public class BriModuleItem
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
