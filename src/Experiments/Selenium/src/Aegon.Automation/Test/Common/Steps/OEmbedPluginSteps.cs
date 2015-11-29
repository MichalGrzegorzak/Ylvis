using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Aegon.Base;
using Aegon.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    public class OEmbedPluginSteps : UrlContextFeatureSteps
    {
        public OEmbedPluginSteps()
        {
            CurrentPage = new BriContentPage();
        }

        public BriContentPage Page
        {
            get { return CurrentPage as BriContentPage; }
        }

        [Then(@"the Flickr image is displayed")]
        public void ThenTheFlickrImageIsDisplayed()
        {
            var img = Page.ContentBlock
                .FindElements(By.TagName("img"))
                .FirstOrDefault();
            Assert.NotNull(img, "No image found");
            var srcAttr = img.GetAttribute("src");
            Assert.IsNotNullOrEmpty(srcAttr, "No src attribute found in the image");
            Assert.IsTrue(srcAttr.Contains("staticflickr.com"), "Wrong image link");
            var classAttr = img.GetAttribute("class");
            Assert.IsNotNullOrEmpty(classAttr, "No class attribute found in the image");
            var imgvStyle = img.GetAttribute("style");
            Assert.IsNotNullOrEmpty(imgvStyle, "No style of the main div element found");
            Assert.AreEqual("max-width:670px;", imgvStyle.Replace(" ", "")); // ignore whitespaces, they doesn't matter
        }

        [Then(@"the YouTube video is displayed")]
        public void ThenTheYouTubeVideoIsDisplayed()
        {
            var iframe = Page.ContentBlock
                .FindElements(By.TagName("iframe"))
                .FirstOrDefault();
            Assert.NotNull(iframe, "No iframe element found");
            var styleAttr = iframe.GetAttribute("style");
            Assert.IsNotNullOrEmpty(styleAttr, "No style attribute found");
            Assert.AreEqual("width:670px;height:377px;", styleAttr.Replace(" ", ""), "Wrong style (width/height)"); // ignore white spaces
            var srcAttr = iframe.GetAttribute("src");
            Assert.IsNotNullOrEmpty(srcAttr, "No src attribute found in the image");
            Assert.IsTrue(srcAttr.StartsWith("http://www.youtube.com/embed/"), "Wrong video link - no youtube reference");
            Assert.IsTrue(srcAttr.EndsWith("wmode=opaque&rel=1"), "Wrong video link - should end with wmode=opaque");
        }

        [Then(@"the Twitter status is displayed")]
        public void ThenTheTwitterStatusIsDisplayed()
        {
            var div = Page.ContentBlock
                .FindElements(By.CssSelector("div.oembed-twitter-container"))
                .FirstOrDefault();
            Assert.NotNull(div, "No div element found with oembed-twitter-container class applied");
            var divStyle = div.GetAttribute("style");
            Assert.IsNotNullOrEmpty(divStyle, "No style of the main div element found");
            Assert.AreEqual("max-width:500px;", divStyle.Replace(" ", "")); // ignore whitespaces, they doesn't matter

            var img = div.FindElements(By.CssSelector("img.oembed-twitter-thumbnail")).FirstOrDefault();
            Assert.NotNull(img, "No img found with oembed-twitter-thumbnail class applied");
            var imgSrc = img.GetAttribute("src");
            Assert.IsNotNullOrEmpty(imgSrc, "Thumbnail image has no src attribute set");
            Assert.IsTrue(imgSrc.StartsWith("https://pbs.twimg.com/profile_images/"), "Wrong img src attribute value");

            var title = div.FindElements(By.CssSelector("p.oembed-twitter-title")).FirstOrDefault();
            Assert.NotNull(title, "No title found");
            var titleLink = title.FindElements(By.TagName("a")).FirstOrDefault();
            Assert.NotNull(titleLink, "Title does not contain link");
            var titleLinkHref = titleLink.GetAttribute("href");
            Assert.IsNotNullOrEmpty(titleLinkHref, "Title link has no href attribute");
            Assert.AreEqual("https://twitter.com/syphernl/status/372593529518034944", titleLinkHref.ToLowerInvariant());
            //Assert.AreEqual("Twitter / sypherNL: I really miss Google Latitude. ...", titleLink.Text.Trim(), "Wrong title");
            var titleLinkSpan = titleLink.FindElements(By.CssSelector("span.screenreader")).FirstOrDefault();
            Assert.NotNull(titleLinkSpan, "No 'external link' helper found");

            //Assert.AreEqual("Twitter / sypherNL: I really miss Google Latitude. ...", titleLink.Text.Replace(titleLinkSpan.GetAttribute("textContent"), string.Empty).Trim(), "Wrong title");

            var content = div.FindElements(By.CssSelector("p.oembed-twitter-content")).FirstOrDefault();
            Assert.NotNull(content, "No conetent found");
            Assert.IsTrue(content.Text.StartsWith("I really miss Google Latitude"), "Wrong content");
        }

        [Then(@"the Facebook status is displayed")]
        public void ThenTheFacebookStatusIsDisplayed()
        {
            var div = Page.ContentBlock
                .FindElements(By.CssSelector("div.oembed-facebook-container"))
                .FirstOrDefault();
            Assert.NotNull(div, "No div element found with oembed-facebook-container class applied");

            var img = div.FindElements(By.CssSelector("img.oembed-facebook-thumbnail")).FirstOrDefault();
            Assert.NotNull(img, "No img found with oembed-facebook-thumbnail class applied");
            var imgSrc = img.GetAttribute("src");
            Assert.IsNotNullOrEmpty(imgSrc, "Thumbnail image has no src attribute set");
            Assert.IsTrue(imgSrc.Contains(".jpg"), "Wrong img src attribute value");

            var title = div.FindElements(By.CssSelector("p.oembed-facebook-title")).FirstOrDefault();
            Assert.NotNull(title, "No title found");
            var titleLink = title.FindElements(By.TagName("a")).FirstOrDefault();
            Assert.NotNull(titleLink, "Title does not contain link");
            var titleLinkHref = titleLink.GetAttribute("href");
            Assert.IsNotNullOrEmpty(titleLinkHref, "Title link has no href attribute");
            Assert.AreEqual("https://www.facebook.com/Aegon", titleLinkHref);
            Assert.IsFalse(string.IsNullOrWhiteSpace(titleLink.Text), "Wrong title");
            var titleLinkSpan = titleLink.FindElements(By.CssSelector("span.screenreader")).FirstOrDefault();
            Assert.NotNull(titleLinkSpan, "No 'external link' helper found");

            var content = div.FindElements(By.CssSelector("p.oembed-facebook-content")).FirstOrDefault();
            Assert.NotNull(content, "No content found");
            Assert.IsFalse(string.IsNullOrWhiteSpace(content.Text), "Wrong content");
        }

        [Then(@"the Google map is displayed")]
        public void ThenTheGoogleMapIsDisplayed()
        {
            var iframe = Page.ContentBlock
                .FindElements(By.TagName("iframe"))
                .FirstOrDefault();
            Assert.NotNull(iframe, "No iframe element found");
            var classAttr = iframe.GetAttribute("class");
            Assert.IsNotNullOrEmpty(classAttr, "No class attribute found");
            Assert.AreEqual("embedly-embed", classAttr, "Wrong css class");
            var srcAttr = iframe.GetAttribute("src");
            Assert.IsNotNullOrEmpty(srcAttr, "No src attribute found for the iframe");
            Assert.IsTrue(srcAttr.StartsWith("http://cdn.embedly.com/widgets/media.html"), "Wrong iframe link - should start with cdn.embedly.com reference");
            Assert.IsTrue(Regex.Matches(srcAttr, @"maps\.google\.com").Count == 2, "Wrong iframe link - should contain 2 maps.google.com references");
            Assert.IsTrue(srcAttr.Contains("maps-api-ssl.google.com") || srcAttr.Contains("maps.gstatic.com"),
                "Wrong iframe link - should contain maps-api-ssl.google.com or maps.gstatic.com reference");
        }

        [Then(@"The caption is (.*)")]
        public void ThenTheCaptionIs(string caption)
        {
            if(string.IsNullOrEmpty(caption))
            {
                Assert.Null(Page.FigCaption);
            }
            else
            {
                Assert.IsNotNull(Page.FigCaption);
                Assert.True(Page.FigCaption.Displayed);
            }
        }

    }
}
