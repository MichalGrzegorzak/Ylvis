using Aegon.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Aegon.Page
{
    public class BriContentPage : BriSidebarContentPage
    {
        #region Page elements
        
        [FindsBy(How = How.Id, Using = "modalContentInside")]
        private IWebElement _contentBlock = null;
        public IWebElement ContentBlock
        {
            get { return _contentBlock.GetElementSafe(); }
        }

        [FindsBy(How = How.CssSelector, Using = ".figureCaption")]
        private IWebElement _figCaption = null;
        public IWebElement FigCaption
        {
            get { return _figCaption.GetElementSafe(); }
        }

        #endregion
    }
}
