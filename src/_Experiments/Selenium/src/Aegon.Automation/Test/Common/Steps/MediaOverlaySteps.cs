using System;
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
    public class MediaOverlaySteps : BaseFeatureSteps
    {
        public MediaOverlaySteps()
        {
            CurrentPage = new BriPage();
        }

        public BriPage Page
        {
            get { return CurrentPage as BriPage; }
        }

        [Then(@"width of the overlay should be (.*)px")]
        public void ThenWidthOfTheOverlayShouldBe(int width)
        {
            var nivo = Page.BodyElement.FindElementSafe(By.CssSelector(".nivo-lightbox-overlay .js-embedly-content"));
            Assert.NotNull(nivo, "Overlay did not open");

            var result = AutomationHelper.Wait(() => Math.Abs(nivo.Size.Width - width) < 50, TimeSpan.FromSeconds(30));

            Assert.IsTrue(result, "Overlay has wrong size");
        }

    }
}
