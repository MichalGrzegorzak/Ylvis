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
    [NUnit.Framework.DescriptionAttribute("Disclaimers tests")]
    public partial class DisclaimersTestsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Disclaimers.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Disclaimers tests", "", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Disclaimer overlay should be displayed after clicking on the link")]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/Home/Investors/News-presentations/Image-Gallery/Executive-Board/", ".ov-links-wrapper a", null)]
        public virtual void DisclaimerOverlayShouldBeDisplayedAfterClickingOnTheLink(string site, string page, string link_Selector, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Disclaimer overlay should be displayed after clicking on the link", exampleTags);
#line 3
this.ScenarioSetup(scenarioInfo);
#line 4
    testRunner.Given(string.Format("I am on the {0} site", site), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 5
    testRunner.When(string.Format("I go to the {0} page", page), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 6
    testRunner.And(string.Format("I click link by {0} selector", link_Selector), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 7
    testRunner.Then("I should see a disclaimer overlay", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Disclaimer overlay should not contain social media links")]
        [NUnit.Framework.TestCaseAttribute("AEGON", "/Home/Investors/News-presentations/Image-Gallery/Executive-Board/", ".ov-links-wrapper a", null)]
        public virtual void DisclaimerOverlayShouldNotContainSocialMediaLinks(string site, string page, string link_Selector, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Disclaimer overlay should not contain social media links", exampleTags);
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
    testRunner.Given(string.Format("I am on the {0} site", site), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
    testRunner.When(string.Format("I go to the {0} page", page), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
    testRunner.And(string.Format("I click link by {0} selector", link_Selector), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
    testRunner.Then("The disclaimer overlay should not contain social media links", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion