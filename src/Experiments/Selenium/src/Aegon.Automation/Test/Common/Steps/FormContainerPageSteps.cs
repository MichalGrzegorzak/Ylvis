using Aegon.Base;
using Aegon.Extensions;
using Aegon.Page;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class FormContainerPageSteps : BaseFeatureSteps
    {
        public FormContainerPageSteps()
        {
            CurrentPage = new FormContainerPage();
        }

        public FormContainerPage Page
        {
            get { return CurrentPage as FormContainerPage; }
        }

        [When(@"I click form submit button")]
        public void WhenIClickFormSubmitButton()
        {
            Assert.IsNotNull(Page.SubmitButton, "XForm submit button should be visible.");

            Page.SubmitButton.ClickSafe();
        }

        [Then(@"I should see a captcha image under the form fields")]
        public void ThenIShouldSeeCaptchaImageUnderFormFields()
        {
            Assert.IsNotNull(Page.CaptchaImage, "Captcha image element should be visible.");
            Assert.IsNotEmpty(Page.CaptchaImage.GetAttribute("src"), "Captcha image's src attribute should not be empty.");
        }
    }
}
