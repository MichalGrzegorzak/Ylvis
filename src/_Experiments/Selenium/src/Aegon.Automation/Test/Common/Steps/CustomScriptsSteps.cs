using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Aegon.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using TechTalk.SpecFlow;
using Aegon.Page;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class CustomScriptsSteps : BaseFeatureSteps
    {
        public CustomScriptsSteps()
        {
            CurrentPage = new BriPage();
        }

        public BriPage Page
        {
            get { return CurrentPage as BriPage; }
        }

        [Then(@"The JavaScript code (.*) should return string value: (.*)")]
        public void ThenTheJavaScriptCodeShouldReturnString(string script, string returnValue)
        {
            var val = AppBrowser.WebDriver.ExecuteJavaScript<string>(script);
            Assert.AreEqual(val, returnValue);
        }
    }
}
