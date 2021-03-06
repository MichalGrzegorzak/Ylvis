﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18063
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Aegon.Test.Common.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Scripts Bundles")]
    [NUnit.Framework.CategoryAttribute("longrunning")]
    public partial class ScriptsBundlesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ScriptsBundles.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Scripts Bundles", "All CSS and Java Scirpt content should be compressed and packed together into bun" +
                    "dles.\r\nInline js and css should be avoided, if nescessary should be documented.", ProgrammingLanguage.CSharp, new string[] {
                        "longrunning"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("I should not see any js errors on page")]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/Home", "on", null)]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/en/Home/About/", "on", null)]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/en/Home/About/asdasdas", "off", null)]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/en/Home/Products/", "on", null)]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/en/Home/About/At-a-glance/", "on", null)]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/en/Home/About/Contact/", "on", null)]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/en/Home/Careers/Job-Seekers-FAQs/", "on", null)]
        public virtual void IShouldNotSeeAnyJsErrorsOnPage(string site, string page, string checkErrorPage, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I should not see any js errors on page", exampleTags);
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given(string.Format("I am on the {0} site", site), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
    testRunner.And(string.Format("I turned {0} ErrorPage checking", checkErrorPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When(string.Format("I go to the {0} page", page), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("there are no js errors", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Print css file should be separate and compressed")]
        [NUnit.Framework.TestCaseAttribute("LOCAL", "/Home", null)]
        [NUnit.Framework.TestCaseAttribute("LOCAL", "/en/Home/About/", null)]
        [NUnit.Framework.TestCaseAttribute("LOCAL", "/en/Home/Products/", null)]
        [NUnit.Framework.TestCaseAttribute("LOCAL", "/en/Home/About/At-a-glance/", null)]
        [NUnit.Framework.TestCaseAttribute("LOCAL", "/en/Home/About/Contact/", null)]
        [NUnit.Framework.TestCaseAttribute("LOCAL", "/en/Home/Careers/Job-Seekers-FAQs/", null)]
        public virtual void PrintCssFileShouldBeSeparateAndCompressed(string site, string page, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Print css file should be separate and compressed", exampleTags);
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
 testRunner.When(string.Format("I go to the {0} page", page), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.Then("there are print.css file included", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
 testRunner.And("print.css file is compressed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("print.css file doesn\'t contain any comments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
