using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Aegon.Base;
using Aegon.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class MicrodataTaggingSteps : BaseFeatureSteps
    {
        public MicrodataTaggingSteps()
        {
            CurrentPage = new BasePage();
        }

        //protected BriPage Page
        //{
        //    get { return CurrentPage as BriPage; }
        //}

        [Then(@"The body microdata tag is present")]
        public void ThenTheBodyMicrodataTagIsPresent()
        {
            var itemscope = CurrentPage.BodyElement.GetAttribute("itemscope");
            Assert.NotNull(itemscope, "'itemscope' microdata tag missing on <body> element");
            Assert.AreEqual("true", itemscope, "'itemscope' microdata tag value on <body> element should be 'true'");

            var itemtype = CurrentPage.BodyElement.GetAttribute("itemtype");
            Assert.NotNull(itemtype, "'itemtype' microdata tag missing on <body> element");
            Assert.AreEqual("http://schema.org/WebPage", itemtype,
                            "'itemtype' microdata tag value on <body> element should be 'http://schema.org/WebPage'");
        }

        [Then(@"The (.*) BRI microdata tags are present")]
        public void ThenTheBriMicrodataTagsArePresent(string breadcrumbTitles)
        {
            var breadcrumbBlock = CurrentPage.BodyElement.FindElement(By.CssSelector("ul.aeg-breadcrumbs"));
            Assert.NotNull(breadcrumbBlock, "Breadcrumb block missing");
            var listItems = breadcrumbBlock.FindElements(By.CssSelector("ul > li")).ToList();
            listItems.Remove(listItems.Last()); // last item is not tagged - it would require making it a link, we do not want it to be a link
            ThenTheMicrodataTagsArePresent(listItems, breadcrumbTitles);
        }

        [Then(@"The (.*) non-BRI microdata tags are present")]
        public void ThenTheNonBriMicrodataTagsArePresent(string breadcrumbTitles)
        {
            var breadcrumbBlock = CurrentPage.BodyElement.FindElement(By.CssSelector("div.breadcrumbs"));
            Assert.NotNull(breadcrumbBlock, "Breadcrumb block missing");
            var listItems = breadcrumbBlock.FindElements(By.CssSelector("div > span")).ToList();
            listItems.RemoveAt(0); // the first element is "Path:" for screenreaders
            ThenTheMicrodataTagsArePresent(listItems, breadcrumbTitles);
        }

        private static void ThenTheMicrodataTagsArePresent(IList<IWebElement> listItems, string breadcrumbTitles)
        {
            var expectedTitles = breadcrumbTitles.Split(';').ToList();

            Assert.AreEqual(expectedTitles.Count, listItems.Count,
                            "Unexpected number of breadcrumb items: {0} instead of {1}", listItems.Count,
                            expectedTitles.Count);

            for (int i = 0; i < listItems.Count; ++i)
            {
                var item = listItems[i];                               

                var itemscope = item.GetAttribute("itemscope");
                Assert.NotNull(itemscope, "'itemscope' microdata tag missing on {0} item", item.Text);
                Assert.AreEqual("true", itemscope, "'itemscope' microdata tag value on <body> element should be 'true'");

                var itemtype = item.GetAttribute("itemtype");
                Assert.NotNull(itemtype, "'itemtype' microdata tag missing on <body> element");
                Assert.AreEqual("http://data-vocabulary.org/Breadcrumb", itemtype,
                                "'itemtype' microdata tag value on {0} element should be 'http://schema.org/Breadcrumb'",
                                item.Text.Trim());

                var anchor = item.FindElement(By.TagName("a"));
                Assert.NotNull(anchor, "No anchor found for {0}", item.Text);
                var urlAttr = anchor.GetAttribute("itemprop");
                Assert.NotNull(urlAttr, "No 'itemprop' found in anchor element of {0}", item.Text);
                Assert.AreEqual("url", urlAttr, "Wrong value of 'itemprop' attribute in anchor element of {0}",
                                item.Text.Trim());

                var span = anchor.FindElement(By.TagName("span"));
                Assert.NotNull(span, "No inner span found for {0}", item.Text);                
                Assert.AreEqual(expectedTitles[i], span.Text.Trim(), "Wrong breadcrumb title");                
                var titleAttr = span.GetAttribute("itemprop");
                Assert.NotNull(titleAttr, "No 'itemprop' found in inner span element of {0}", item.Text);
                Assert.AreEqual("title", titleAttr, "Wrong value of 'itemprop' attribute in inner span element of {0}",
                                item.Text.Trim());
            }
        }
    }
}
