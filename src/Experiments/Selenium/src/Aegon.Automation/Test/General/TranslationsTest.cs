using Aegon.Base;
using Aegon.Base.TestRunner;
using Aegon.Page;
using NUnit.Framework;

namespace Aegon.Test.General
{
    [TestDescriptor(ID = "TRANSLATIONS", Description = "Translation Test")]
    internal class TranslationsTest: ITest
    {
        BasePage page = null;

        private const string missingText = "[Missing text";

        public string ID
        {
            get
            {
                return "TRANSLATIONS";
            }
        }

        public void Initialize(TestRunnerEngine runner, WebBrowser webBrowser)
        {
            page = new BasePage();
            page.Initialize(webBrowser.WebDriver);
        }

        public void Execute(WebBrowser webBrowser)
        {
            Assert.False(webBrowser.WebDriver.PageSource.Contains(missingText));                        
        }


        public void FinalExecute(WebBrowser webBrowser)
        {
            Assert.True(true);
        }
    }
}
