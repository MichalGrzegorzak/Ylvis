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
    [NUnit.Framework.DescriptionAttribute("PerformanceTests")]
    [NUnit.Framework.IgnoreAttribute()]
    [NUnit.Framework.CategoryAttribute("performance")]
    public partial class PerformanceTestsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PerformanceTests.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "PerformanceTests", "Monitoring site perfoemance using firefox net panel (net export tool), and yslow/" +
                    "page speed tools (ff extensions, with beacon option - saving result to remote ur" +
                    "l - harlog.exe as a tool that act remote server)", ProgrammingLanguage.CSharp, new string[] {
                        "ignore",
                        "performance"});
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
        [NUnit.Framework.DescriptionAttribute("Save net panel results")]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/Home", null)]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/en/Home/About/", null)]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/en/Home/Products/", null)]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/en/Home/About/At-a-glance/", null)]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/en/Home/About/Contact-Us/", null)]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/en/Home/Careers/Job-Seekers-FAQs/", null)]
        public virtual void SaveNetPanelResults(string site, string page, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Save net panel results", exampleTags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given(string.Format("I am on the {0} site", site), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When(string.Format("I go to the {0} page", page), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("net panel results are saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Save yslow results")]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/Home", null)]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/en/Home/About/", null)]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/en/Home/Products/", null)]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/en/Home/About/At-a-glance/", null)]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/en/Home/About/Contact-Us/", null)]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/en/Home/Careers/Job-Seekers-FAQs/", null)]
        public virtual void SaveYslowResults(string site, string page, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Save yslow results", exampleTags);
#line 22
 this.ScenarioSetup(scenarioInfo);
#line 23
 testRunner.Given(string.Format("I am on the {0} site", site), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.When(string.Format("I go to the {0} page", page), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.Then("YSlow results are saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
