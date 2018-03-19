using Aegon.Base;
using Aegon.Extensions;
using Aegon.Page;

using NUnit.Framework;

using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class LinksBehavioursSteps : BaseFeatureSteps
    {

        public LinksBehavioursSteps()
        {
            CurrentPage = new BasePage();
        }
        
        [Then(@"External Links Are Mareked")]
        public void ThenExternalLinksAreMareked()
        {
            var links = CurrentPage.BodyElement.FindElements(By.TagName("a"));  //TODO: implement find elements safe
            foreach (var webElement in links)
            {
                var href = webElement.GetAttribute("href"); //TODO: cast/create Link//Href class
                var currentUrl = AppBrowser.WebDriver.Url; //TODO: use helper class/URL/URI for detecting external links
                currentUrl = currentUrl.Replace("http://", string.Empty).Replace("https://", string.Empty);
                var slashIndex = currentUrl.IndexOf("/");
                if (slashIndex > 0) currentUrl = currentUrl.Remove(slashIndex);

                if (!string.IsNullOrWhiteSpace(href) && !href.Contains(currentUrl))
                {
                    var screenreaderSpan = webElement.FindElementSafe(By.ClassName("screenreader"));
                    Assert.IsNotNull(screenreaderSpan);
                    //Assert.True(!string.IsNullOrWhiteSpace(screenreaderSpan.GetAttribute("textContent"))); //TODO: heleper for spans, not every scereenreader link had (extrnali link) content, need to be checked
                }
            }
        }
    }
}
