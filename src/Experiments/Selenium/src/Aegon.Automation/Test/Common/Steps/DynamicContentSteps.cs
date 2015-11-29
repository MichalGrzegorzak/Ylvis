using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aegon.Base;
using Aegon.Page;
using Aegon.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    // Requirements:
    // Lightbox open the following sandbox page (24472): en/BRI-Home/BRI-Landingpage/Brands/ 

    [Binding]
    public class DynamicContentSteps : UrlContextFeatureSteps
    {
        public DynamicContentSteps()
        {
            CurrentPage = new BriContentPage();
        }

        public BriContentPage Page
        {
            get { return CurrentPage as BriContentPage; }
        }

        [Then(@"the quote is displayed")]
        public void ThenTheQuoteIsDisplayed()
        {
            var blockquoteContent = Page.ContentBlock.FindElementSafe(By.CssSelector("blockquote div"));

            Assert.IsNotNull(blockquoteContent, "Blockquote content element is expected");
            Assert.IsNotNull(blockquoteContent.Text, "Blockquote content is expected");
            Assert.IsTrue(blockquoteContent.Text.Contains("This is a quote text."));
        }

        [Then(@"the lightbox link is displayed")]
        public void ThenTheLightboxIsDisplayed()
        {
            var lightboxLink = Page.ContentBlock.FindElementSafe(By.CssSelector("a.lightbox"));

            Assert.IsNotNull(lightboxLink, "Lightbox link element is expected");
            Assert.IsNotNull(lightboxLink, "Lightbox link element is expected");
        }

        [When(@"click on the dynamic content lightbox link")]
        public void WhenClickOnTheDynamicContentLightboxLink()
        {
            var lightboxLink = Page.ContentBlock.FindElementSafe(By.CssSelector("a.lightbox"));
            lightboxLink.Click();
        }

        [Then(@"I should see the dynamic content lightbox popup")]
        public void ThenIShouldSeeTheDynamicContentLightboxPopup()
        {
            var lightboxPopup = Page.BodyElement.FindElementSafe(By.CssSelector(".overlay-content"));
            Assert.IsNotNull(lightboxPopup, "Lightbox popup should be displayed");
        }

    }
}
