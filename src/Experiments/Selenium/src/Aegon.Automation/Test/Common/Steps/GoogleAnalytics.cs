using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Aegon.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    public class GoogleAnalytics : UrlContextFeatureSteps
    {
        [When(@"I mock GoogleAnalytics")]
        public static void WhenIMockGoogleAnalytics()
        {
            const string script = 
                "_gaq = { "
                + "     push: function(p) { " 
                + "         this.stack.push(p);"
                + "     },"
                + "     stack: []"
                + "};"
                + ""
                + "return true;";
            Assert.AreEqual(true, AppBrowser.WebDriver.ExecuteJavaScript<bool>(script));
        }

        [When(@"I terminate the click event of (.*)")]
        public static void WhenITerminateTheClickEvent(string id)
        {
            string script = String.Format("document.getElementById('{0}').onclick = function() {{ return false; }}; return true;", id);
            Assert.AreEqual(true, AppBrowser.WebDriver.ExecuteJavaScript<bool>(script));
        }

        [Then(@"the page view should (not)? be tracked as (.*)")]
        public static void ThenThePageViewShouldBeTrackedAs(string not, string text)
        {
            var e = GetTrackedPageview(text);
            if (isNot(not))
            {
                Assert.IsTrue(!e.Any(), "There should be no event tracked");
            }
            else
            {
                Assert.IsTrue(e.Count() == 1, "The event should be _trackPageView");                
            }
        }

        [Then(@"the event should (not)? be tracked as (.*) and (.*) and (.*)")]
        public static void ThenThePageViewShouldBeTrackedAs(string not, string area, string action, string id)
        {
            var e = GetTrackedEvent(area, action, id);
            if (isNot(not))
            {
                Assert.IsTrue(!e.Any(), "There should be no event tracked");
            }
            else
            {
                Assert.IsTrue(e.Count() == 1, "The event should be _trackEvent");
            }
        }

        private static bool isNot(string not)
        {
            return not == "not";
        }

        private static IEnumerable<ReadOnlyCollection<object>> GetTrackedEvent(string area, string action, string id)
        {
            object r = ExecuteScript("return _gaq.stack");
            Assert.IsInstanceOf<ReadOnlyCollection<object>>(r);
            var collection = (ReadOnlyCollection<object>) r;
            var e = from i in collection
                let c = i as ReadOnlyCollection<object>
                where c != null
                      && c.Count == 4
                      && (string) c[0] == "_trackEvent"
                      && (string) c[1] == area
                      && (string) c[2] == action
                      && (string) c[3] == id
                select c;            
            return e;
        }

        private static IEnumerable<ReadOnlyCollection<object>> GetTrackedPageview(string text)
        {
            object r = ExecuteScript("return _gaq.stack");
            Assert.IsInstanceOf<ReadOnlyCollection<object>>(r);
            var collection = (ReadOnlyCollection<object>)r;
            var e = from i in collection
                let c = i as ReadOnlyCollection<object>
                where c != null
                      && c.Count == 2
                      && (string) c[0] == "_trackPageview"
                      && (string) c[1] == text
                select c;
            return e;
        }

        private static object ExecuteScript(string script)
        {
            return ((IJavaScriptExecutor)AppBrowser.WebDriver).ExecuteScript(script);
        }
    }
}
