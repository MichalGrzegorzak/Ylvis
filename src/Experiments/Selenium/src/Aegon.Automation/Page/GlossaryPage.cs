using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Aegon.Page
{
    public class GlossaryPage : BasePage
    {
        #region Page elements

        [FindsBy(How = How.CssSelector, Using = ".aeg-acc-header > a")]
        private IList<IWebElement> _glossaryTriggerElements = null;
        public IList<IWebElement> GlossaryTriggerElements { get { return _glossaryTriggerElements; } }

        #endregion

        public IWebElement FindItemTriggerElement(string title)
        {
            try
            {
                return GlossaryTriggerElements.FirstOrDefault(x => x.Text == title);
            }
            catch
            {

                return null;
            }
        }

        public IEnumerable<IWebElement> GetDescriptionElements()
        {
            return BodyElement.FindElements(By.CssSelector(".aeg-acc-content")).Where(x => x.Displayed);
        }
    }

}
