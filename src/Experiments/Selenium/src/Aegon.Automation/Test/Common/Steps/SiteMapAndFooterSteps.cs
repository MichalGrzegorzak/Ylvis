using System.Linq;
using System.Threading;
using Aegon.Base;
using Aegon.Extensions;
using Aegon.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class SiteMapAndFooterSteps : BaseFeatureSteps
    {
        public SiteMapAndFooterSteps()
        {
            CurrentPage = new MasterPage();
        }

        public MasterPage Page
        {
            get { return CurrentPage as MasterPage; }
        }

        [When(@"I click Sitemap")]
        public void WhenIClickOnSitemap()
        {
            Page.SitemapLinkIntheFooter.Click();
        }

        [When(@"I click Other Aegon Websites")]
        public void WhenIClickOnOtherAegonWebsites()
        {
            Page.OtherAegonSiteDropdownInFooter.Click();
        }
        
        [Then(@"I see sitemap section under footer")]
        public void ThenISeeSitemapSectionUnderFooter()
        {
            Thread.Sleep(3000);
            var footerSitemap = Page.SitemapListLocator;
            Assert.IsTrue(footerSitemap != null, "Sitemap in footer not found");
            Assert.IsTrue(footerSitemap.All(elem => elem.Displayed), "Sitemap is not displayed");
            Assert.IsTrue(footerSitemap.All(elem => elem.FindElements(By.TagName("a")).Any() && elem.FindElements(By.TagName("a")).All(a => !string.IsNullOrWhiteSpace(a.Text))), "Sitmap doesn't contain links");
        }

        [Then(@"I see Other Aegon Websites list")]
        public void ThenISeeOtherSitesList()
        {
            var footerOtherWebsitesLists = Page.OtherAegonSitesLists.Where(column => column.FindElementSafe(By.CssSelector("h2>.category-name")) != null).Select(column => column).ToList();

            var globalColumn = footerOtherWebsitesLists.Where(
                column => column.FindElement(By.CssSelector("h2>.category-name")).Text.Contains("Global sites"))
                                                       .Select(column => column)
                                                       .Single();
            var countriesColumn = footerOtherWebsitesLists.Where(
                column => column.FindElement(By.CssSelector("h2>.category-name")).Text.Contains("Country sites"))
                                                       .Select(column => column)
                                                       .Single();
            var otherColumn = footerOtherWebsitesLists.Where(
                column => column.FindElement(By.CssSelector("h2>.category-name")).Text.Contains("Other sites"))
                                                       .Select(column => column)
                                                       .Single();

            var globalLinks = globalColumn.FindElements(By.TagName("a")).ToList();
            var countriesLinks = countriesColumn.FindElements(By.TagName("a")).ToList();
            var otherLinks = otherColumn.FindElements(By.TagName("a")).ToList();

            Assert.IsTrue(footerOtherWebsitesLists != null, "'Other Aegon Websites' panel in footer not found");
            Assert.IsTrue(footerOtherWebsitesLists.Count == 3 && footerOtherWebsitesLists.All(column => column.Displayed), "Not all three columns with links are present and displayed");
            Assert.IsTrue(globalLinks.Any() && globalLinks.All(link => !string.IsNullOrWhiteSpace(link.Text)), "'Global sites' panel doesn't contain links");
            Assert.IsTrue(countriesLinks.Any() && countriesLinks.All(link => !string.IsNullOrWhiteSpace(link.Text)), "'Country sites' panel doesn't contain links");
            Assert.IsTrue(otherLinks.Any() && otherLinks.All(link => !string.IsNullOrWhiteSpace(link.Text)), "'Other sites' panel doesn't contain links");
        }
    }
}
