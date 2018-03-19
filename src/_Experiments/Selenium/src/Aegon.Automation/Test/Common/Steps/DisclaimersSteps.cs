using System;
using Aegon.Base;
using Aegon.Extensions;
using Aegon.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class DisclaimersSteps : BaseFeatureSteps
    {
        public DisclaimersSteps()
        {
            CurrentPage = new BasePage();
        }

        public BasePage Page
        {
            get { return CurrentPage; }
        }

        private IWebElement GetOverlayElement()
        {
            return Page.BodyElement.FindElementSafe(By.CssSelector(".nivo-lightbox-overlay .overlay-content"));
        }

        [Then(@"I should see a disclaimer overlay")]
        public void ThenIShouldSeeDisclaimerOverlay()
        {
            var overlay = GetOverlayElement();
            Assert.NotNull(overlay, "Overlay did not open");
        }

        [Then(@"The disclaimer overlay should not contain social media links")]
        public void ThenTheDisclaimerOverlayShouldNotContainSocialMediaLinks()
        {
            var overlay = GetOverlayElement();
            Assert.NotNull(overlay, "Overlay did not open");

            WebElementExtensions.WaitForElement(AppBrowser.WebDriver, TimeSpan.FromSeconds(30), By.CssSelector(".overlay-content #modalContentInside"));

            var socialMediaElement = overlay.FindElementSafe(By.CssSelector(".aeg-addthis-container"));
            Assert.IsNull(socialMediaElement, "Social media elements are displayed in the overlay");
        }
    }
}
