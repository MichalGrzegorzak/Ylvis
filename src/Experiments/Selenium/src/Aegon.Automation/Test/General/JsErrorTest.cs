using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aegon.Base;
using Aegon.Base.TestRunner;
using Aegon.Page;
using JSErrorCollector;
using NUnit.Framework;

namespace Aegon.Test.General
{
    [TestDescriptor(ID = JsErrorTestId, Description = "Dummy test, always successful")]
    internal class JsErrorTest : ITest
    {
        private class Error
        {
            public string Url { get; set; }
            public JavaScriptError JsError { get; set; }
        }

        public const string JsErrorTestId = "JS_ERROR";
        public string ID { get { return JsErrorTestId; } }

        private TestRunnerEngine _runner;

        public void Initialize(TestRunnerEngine runner, WebBrowser webBrowser)
        {
            _runner = runner;
        }

        public void Execute(WebBrowser webBrowser)
        {
            var jsErrors = JavaScriptError.ReadErrors(webBrowser.WebDriver);
            if (jsErrors != null)
            {
                foreach (var e in jsErrors)
                {
                    _runner.AddResult(new TestResult
                    {                               
                        Passed = false,
                        PageUrl = webBrowser.WebDriver.Url,
                        TestID = ID,
                        Message = String.Format("URL: {0}, Line {1}, Script {2}, Message {3}",
                            webBrowser.WebDriver.Url, e.LineNumber, e.SourceName, e.ErrorMessage)
                    });
                }
            }
        }

        public void FinalExecute(WebBrowser webBrowser)
        { }
    }
}
