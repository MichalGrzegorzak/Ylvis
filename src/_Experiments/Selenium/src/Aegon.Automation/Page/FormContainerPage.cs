using Aegon.Extensions;
using OpenQA.Selenium;

namespace Aegon.Page
{
    public class FormContainerPage : BasePage
    {
        #region Page elements

        public IWebElement SubmitButton
        {
            get { return BodyElement.FindElementSafe(By.CssSelector("fieldset .btn input")); }
        }

        public IWebElement CaptchaImage
        {
            get { return BodyElement.FindElementSafe(By.CssSelector("fieldset .captcha img")); }
        }

        #endregion
    }
}
