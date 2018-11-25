using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aegon.Base.TestRunner
{
    internal interface ITestResult
    {
        bool Passed { get; set; }
        string TestID { get; set; }
        string PageUrl { get; set; }
        string Message { get; set; }
        Exception InnerException { get; set; }
    }

    public class TestResult : ITestResult
    {
        public string TestID { get; set; }
        public bool Passed { get; set; }
        public string Message { get; set; }
        public string PageUrl { get; set; }
        public Exception InnerException { get; set; }

        public override string ToString()
        {
            return string.Format("-> {0}: {1} ({2}) -> {3}", Passed ? "done" : "failed", TestID, PageUrl, Message);
        }
    }
}
