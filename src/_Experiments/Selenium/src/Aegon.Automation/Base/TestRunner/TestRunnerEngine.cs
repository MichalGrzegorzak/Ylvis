using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aegon.Helpers;
using Aegon.Features.Reflection;

namespace Aegon.Base.TestRunner
{
    internal class TestRunnerEngine
    {
        private List<ITestResult> _results = new List<ITestResult>();

        public IEnumerable<ITestResult> Results
        {
            get
            {
                return _results.ToArray();
            }
        }

        public IEnumerable<ITestResult> Failures
        {
            get
            {
                return _results.Where(x => !x.Passed).ToArray();
            }
        }

        public void AddResult(ITestResult result)
        {
            _results.Add(result);
        }

        public void Run(WebBrowser webBrowser, string rootUrl, string pageTypes, string languageBranch, string testIDs, int maxPages = -1)
        {
            IEnumerable<string> pageUrls = GetDescendantPages(
                webBrowser, rootUrl, pageTypes, string.IsNullOrWhiteSpace(languageBranch) ? null : languageBranch);

            IEnumerable<ITest> tests = GetTestCases(testIDs);

            SetupErrorPages(webBrowser, rootUrl, languageBranch);

            var typeDictionary = new PageTypeDictionary(webBrowser.BaseUrl, maxPages);

            foreach (var pageUrl in pageUrls)
            {
                if (typeDictionary.ShouldProcess(pageUrl))
                {
                    webBrowser.NavigateToPage(pageUrl);
                    foreach (var test in tests)
                    {
                        try
                        {
                            test.Initialize(this, webBrowser);
                            test.Execute(webBrowser);

                            _results.Add(new TestResult() {Passed = true, TestID = test.ID, PageUrl = pageUrl});
                        }
                        catch (Exception ex)
                        {
                            _results.Add(new TestResult()
                            {
                                Passed = false,
                                TestID = test.ID,
                                PageUrl = pageUrl,
                                Message = ex.Message,
                                InnerException = ex.InnerException
                            });
                        }
                    }
                }
            }

            foreach (var test in tests)
            {
                try
                {
                    test.FinalExecute(webBrowser);                                        
                }
                catch (Exception ex)
                {
                    _results.Add(new TestResult() { Passed = false, TestID = test.ID, PageUrl = string.Empty, Message = ex.Message, InnerException = ex.InnerException });
                }
            }
        }

        private string[] GetDescendantPages(WebBrowser webBrowser, string pageUrl, string pageTypes, string languageBranch = "en")
        {
            string[] typesCollection = null;
            pageTypes = (pageTypes ?? string.Empty).Trim();

            if (pageTypes != "*")
                typesCollection = pageTypes.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            return CmsHelper.GetDescendantPages(webBrowser.BaseUrl, pageUrl, typesCollection, languageBranch)
                .Select(x => x.FriendlyURL)
                .ToArray();
        }

        private IEnumerable<ITest> GetTestCases(string testIDs)
        {
            var list = new List<ITest>();
            var ids = testIDs.Split(new [] {';'}, StringSplitOptions.RemoveEmptyEntries);
            var testTypes = GetTestCaseTypes(ids);

            foreach (var type in testTypes)
            {
                list.Add((ITest)Activator.CreateInstance(type));
            }

            return list.ToArray();
        }

        private IEnumerable<Type> GetTestCaseTypes(string[] testIDs)
        {
            var list = new List<Type>();
            var testTypes = AssemblyReflector.Instance.GetClasses<ITest>();

            foreach (var testType in testTypes)
            {
                var descriptorAttr = AssemblyReflector.Instance.GetTypeAttribute<TestDescriptorAttribute>(testType);
                if (descriptorAttr == null)
                    continue;

                if (testIDs.Contains(descriptorAttr.ID) && !descriptorAttr.Ignored)
                    list.Add(testType);
            }

            return list.ToArray();
        }

        private void SetupErrorPages(WebBrowser webBrowser, string rootUrl, string languageBranch)
        {
            IEnumerable<string> errorPageUrls = GetDescendantPages(
                webBrowser, rootUrl, "[TLB Templates] Custom error page;[Templates] Custom error page", string.IsNullOrWhiteSpace(languageBranch) ? null : languageBranch);

            webBrowser.SetupErrorPagesUrls(errorPageUrls);
        }
    }
}
