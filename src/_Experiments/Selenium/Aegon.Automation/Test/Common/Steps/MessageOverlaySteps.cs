using System.Threading;
using Aegon.Page;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class MessageOverlaySteps : Base.Base
    {

        [Given(@"I am on BRI Homepage of Aegon (.*)")]
        public void GivenIamOnBriHomepageOfAegon(string site)
        {
            SignInToEnvironment();
            Driver.Navigate().GoToUrl(RoBriHomePageUrl);
            
        }

        [Then(@"the message overlay appears after (.*) seconds")]
        public void ThenTheMessageOverlayAppearsAfterSeconds(int seconds)
        {
            Thread.Sleep(seconds * 1000 + 2000);
            var masterPage = new MasterPage();
            Assert.IsTrue(FindElement(masterPage.MessageOverlayLocator).Displayed);

        }

        [Then(@"the text on the overlay should be (.*)")]
        public void ThenTheTextOnTheOverlayShouldBe(string text)
        {
            var masterPage = new MasterPage();
            Assert.IsTrue(FindElement(masterPage.MessageOverlayLocator).Text.ToLower().Contains(text.ToLower()));
        }


    }
}
