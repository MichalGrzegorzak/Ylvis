using System;
using System.Linq;
using Aegon.Base;
using Aegon.Base.TestRunner;
using JSErrorCollector;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class GeneralTestsSteps : BaseFeatureSteps
    {
        private TestRunnerEngine testRunner = new TestRunnerEngine();

        [When(@"I navigate through (-?[0-9]+) (.*) descendant pages of type (.*) in language (.*) and perform (.*) tests")]
        public void WhenINavigateTroughDescendantPagesAndPerformTests(int maxPages, string rootUrl, string pageTypes, string languageBranch,  string testIDs)
        {
            testRunner.Run(AppBrowser, rootUrl, pageTypes,languageBranch, testIDs, maxPages);
        }

        [Then(@"I should not get any error")]
        public void ThenIShouldNotGetAnyError()
        {
            foreach (var msg in testRunner.Failures)
                Console.WriteLine(msg);

            Assert.IsTrue(testRunner.Failures.Any() == false, "There were some errors.");
        }

        [Then(@"There is (.+) js error")]
        public void ThenThereIsJsError(string errorMessage)
        {
            //https://github.com/protectedtrust/JSErrorCollector.NET
            //http://mguillem.wordpress.com/2011/10/11/webdriver-capture-js-errors-while-running-tests/
            //https://code.google.com/p/selenium/issues/detail?id=148
            //https://github.com/dharrya/ChromeJSErrorCollector

            var jsErrors = JavaScriptError
                .ReadErrors(AppBrowser.WebDriver)
                .ToArray();
            Assert.IsTrue(jsErrors.Any());
            Assert.AreEqual(errorMessage, jsErrors.First().ErrorMessage);
        }

    }
}
