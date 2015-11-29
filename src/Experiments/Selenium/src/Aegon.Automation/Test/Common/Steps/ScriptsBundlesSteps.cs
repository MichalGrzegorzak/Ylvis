using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aegon.Base;
using Aegon.Page;
using JSErrorCollector;

using NUnit.Framework;

using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class ScriptsBundlesSteps : BaseFeatureSteps 
    {
        public ScriptsBundlesSteps()
        {
            CurrentPage = new BasePage();
        }

        [Then(@"there are no js errors")]
        public void ThenThereAreNoJsErrors()
        {
            //https://github.com/protectedtrust/JSErrorCollector.NET
            //http://mguillem.wordpress.com/2011/10/11/webdriver-capture-js-errors-while-running-tests/
            //https://code.google.com/p/selenium/issues/detail?id=148
            //https://github.com/dharrya/ChromeJSErrorCollector

            var jsErrors = JavaScriptError.ReadErrors(AppBrowser.WebDriver);
            if (jsErrors != null)
            {                
                StringBuilder log = new StringBuilder();
                jsErrors.ToList()
                        .ForEach(
                            l =>
                            log
                                .AppendFormat("URL: {0}", CurrentPage.Url)
                                .AppendLine()
                                .AppendFormat("Line {0} Script {1} Message {2} ", l.LineNumber, l.SourceName, l.ErrorMessage));
                Assert.False(jsErrors.Any(), "JS Errors found" + Environment.NewLine + log.ToString()); 
            }
        }

        [Then(@"there are print\.css file included")]
        public void ThenThereArePrint_CssFileIncluded()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"print\.css file is compressed")]
        public void ThenPrint_CssFileIsCompressed()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"print\.css file doesn't contain any comments")]
        public void ThenPrint_CssFileDoesnTContainAnyComments()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
