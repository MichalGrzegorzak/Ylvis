using System.Linq;
using Aegon.Base;
using Aegon.Page;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class RssFeedsSteps : BaseFeatureSteps
    {
        public RssFeedsSteps()
        {
            CurrentPage = new RssFeedPage();
        }

        public RssFeedPage Page
        {
            get { return CurrentPage as RssFeedPage; }
        }

        [Then(@"I should be able to read RSS feeds")]
        public void ThenIShouldBeAbleToReadRssFeeds()
        {
            Assert.IsTrue(Page.IsValidRssDocument, "The page does not return valid rss structure.");
            CollectionAssert.IsNotEmpty(Page.ChannelItems, "Rss channel should contain at least one item.");
            Assert.IsTrue(Page.ChannelItems.All(x => !string.IsNullOrEmpty(x.Title)), "All RSS items should contain Title element.");
        }
    }
}
