using Aegon.Base;
using Aegon.Base.TestRunner;
using Aegon.Page;
using NUnit.Framework;

namespace Aegon.Test.General
{
    [TestDescriptor(ID = "SAMPLE", Description = "Sample Test")]
    internal class SampleTest : ITest
    {
        BasePage page = null;
        private TestRunnerEngine _runner;

        public string ID
        {
            get
            {
                return "SAMPLE";
            }
        }

        public void Initialize(TestRunnerEngine runner, WebBrowser webBrowser)
        {
            page = new BasePage();
            page.Initialize(webBrowser.WebDriver);
        }

        public void Execute(WebBrowser webBrowser)
        {
            Assert.AreEqual("SAMPLE", "SAMPLE");
        }


        public void FinalExecute(WebBrowser webBrowser)
        {
            Assert.True(true);
        }
    }
}
