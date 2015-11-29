using System;
using System.Linq;
using Aegon.Base;
using Aegon.Extensions;
using Aegon.Helpers;
using Aegon.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class BriOverviewPageSteps : BaseFeatureSteps
    {

        public BriOverviewPageSteps()
        {
            CurrentPage = new BriOverviewPage();
        }

        public BriOverviewPage Page
        {
            get { return CurrentPage as BriOverviewPage; }
        }

        private string[] GetCommaSeparatedToArray(string sections)
        {
            return sections.Split(',');
        }

        [Then(@"I should see sections like (.*)")]
        public void ThenIShouldSeeImagesPressReleasesNews(string sections)
        {
            var sectionsTable = GetCommaSeparatedToArray(sections);
            Assert.AreEqual(sectionsTable.Length, Page.SectionElements.Count);

            var actualTitles = Page.GetSectionTitlesTexts();
            foreach (var expectedTitle in sectionsTable)
            {
                Assert.True(actualTitles.Contains(expectedTitle));
            }

        }

        [Then(@"I should see (.*) pagers")]
        public void ThenIShouldSeePagers(int pagersNumber)
        {
            Assert.True(Page.Pagers.Count == pagersNumber);
            if (pagersNumber > 0)
            {
                Assert.False(Page.IsPagerEmpty());
            }
            else
            {
                Assert.True(Page.IsPagerEmpty());
            }
        }


        [Then(@"Page number (.*) should be selected")]
        public void ThenPageNumberShouldBeSelected(int pageNumber)
        {
            Assert.AreEqual(pageNumber, Page.GetCurrentPageNumber());
        }

        [Then(@"I should see no pages")]
        public void ThenIShouldSeeNoPages()
        {
            Assert.True(Page.IsPagerEmpty());
        }

        [Then(@"I should see items in sections like (.*)")]
        public void ThenIShouldSeeItemsInSectionsLike(string sections)
        {
            var expectedSections = GetCommaSeparatedToArray(sections);
            foreach (var sectionTitle in expectedSections)
            {
                Assert.False(Page.IsSecionEmpty(Page.GetSection(sectionTitle)));
            }
            Assert.True(Page.SectionElements.Count == expectedSections.Count());
        }

        [Then(@"I should see sections (.*) containing html elements inside with specific css class like (.*)")]
        public void ThenIShouldSeeSectionsContainingHtmlElementsInsideWithSpecificCssClassLike(string sections, string classes)
        {
            foreach (var sectionTitle in GetCommaSeparatedToArray(sections))
            {
                Assert.True(Page.IsContaningAllCssElements(Page.GetSection(sectionTitle), GetCommaSeparatedToArray(classes)));
            }
        }

        [When(@"I select section filter (.*)")]
        public void WhenISelectSectionFilter(string filterName)
        {
            Page.OpenDropDown();

            Page.SelectFilter(filterName);
        }

        [Then(@"I should see all first level (.*)")]
        public void ThenIShouldSeeAllFirstLevel(string expectedFilters)
        {
            Page.OpenDropDown();
            var actualFilters = Page.GetFirstLevelFilters();
            foreach (var expectedFilter in GetCommaSeparatedToArray(expectedFilters))
            {
                Assert.True(actualFilters.Contains(expectedFilter));
            }
        }

        [When(@"I close cookie prompt")]
        public void WhenICloseCookiePrompt()
        {
            AutomationHelper.WaitSeconds(3);
            CurrentPage.PageSetup();
        }

        [When(@"I select page size (.*)")]
        public void WhenISelectPageSize(string pageSize)
        {
            Page.OpenPageSizeDropDown();
            Page.SelectPageSize(pageSize);
        }

        [Then(@"I should see an overlay titled (.*)")]
        public void ThenIShouldSeeAnOverlay(string overlayTitle)
        {
            var nivo = Page.BodyElement.FindElementSafe(By.CssSelector(".nivo-lightbox-overlay"));
            Assert.NotNull(nivo, "Overlay did not open");

            var result = AutomationHelper.Wait(() => nivo.Text.StartsWith(overlayTitle), TimeSpan.FromSeconds(30));

            Assert.IsTrue(result, "Overlay has wrong title");
        }

    }
}
