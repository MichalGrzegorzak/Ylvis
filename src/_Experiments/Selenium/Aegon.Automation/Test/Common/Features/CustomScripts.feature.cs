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
    [NUnit.Framework.DescriptionAttribute("Custom scripts tests")]
    public partial class CustomScriptsTestsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CustomScripts.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Custom scripts tests", "", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Sitewide header script checks")]
        [NUnit.Framework.TestCaseAttribute("SANDBOX", "SitewideHeaderScriptPlaceholder", "<script>window.customScriptVariable = \'testHeader\';</script>", "SitewideFooterScriptPlaceholder", "", "ScriptPlaceholder", "", "/custom-scripts/content-page", "return window.customScriptVariable;", "testHeader", null)]
        public virtual void SitewideHeaderScriptChecks(string site, string headerScriptProperty, string headerScript, string footerScriptProperty, string footerScript, string pageScriptProperty, string pageScript, string page, string verificationScript, string verificationValue, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sitewide header script checks", exampleTags);
#line 3
this.ScenarioSetup(scenarioInfo);
#line 4
    testRunner.Given(string.Format("On the {0} homepage I set the value of {1} to {2}", site, headerScriptProperty, headerScript), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 5
    testRunner.Given(string.Format("On the {0} homepage I set the value of {1} to {2}", site, footerScriptProperty, footerScript), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
    testRunner.Given(string.Format("On {0} site I have prepared {1} content page", site, page), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
    testRunner.Given(string.Format("On {0} {1} I set the value of {2} property to {3}", site, page, pageScriptProperty, pageScript), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
    testRunner.When("I go to that page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
    testRunner.Then(string.Format("The JavaScript code {0} should return string value: {1}", verificationScript, verificationValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Sitewide footer script checks")]
        [NUnit.Framework.TestCaseAttribute("SANDBOX", "SitewideHeaderScriptPlaceholder", "", "SitewideFooterScriptPlaceholder", "<script>window.customScriptVariable = \'testFooter\';</script>", "ScriptPlaceholder", "", "/custom-scripts/content-page", "return window.customScriptVariable;", "testFooter", null)]
        public virtual void SitewideFooterScriptChecks(string site, string headerScriptProperty, string headerScript, string footerScriptProperty, string footerScript, string pageScriptProperty, string pageScript, string page, string verificationScript, string verificationValue, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sitewide footer script checks", exampleTags);
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
    testRunner.Given(string.Format("On the {0} homepage I set the value of {1} to {2}", site, headerScriptProperty, headerScript), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
    testRunner.Given(string.Format("On the {0} homepage I set the value of {1} to {2}", site, footerScriptProperty, footerScript), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
    testRunner.Given(string.Format("On {0} site I have prepared {1} content page", site, page), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
    testRunner.Given(string.Format("On {0} {1} I set the value of {2} property to {3}", site, page, pageScriptProperty, pageScript), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
    testRunner.When("I go to that page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
    testRunner.Then(string.Format("The JavaScript code {0} should return string value: {1}", verificationScript, verificationValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Page script checks")]
        [NUnit.Framework.TestCaseAttribute("SANDBOX", "SitewideHeaderScriptPlaceholder", "", "SitewideFooterScriptPlaceholder", "", "ScriptPlaceholder", "<script>window.customScriptVariable = \'testPage\';</script>", "/custom-scripts/content-page", "return window.customScriptVariable;", "testPage", null)]
        public virtual void PageScriptChecks(string site, string headerScriptProperty, string headerScript, string footerScriptProperty, string footerScript, string pageScriptProperty, string pageScript, string page, string verificationScript, string verificationValue, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Page script checks", exampleTags);
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
    testRunner.Given(string.Format("On the {0} homepage I set the value of {1} to {2}", site, headerScriptProperty, headerScript), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
    testRunner.Given(string.Format("On the {0} homepage I set the value of {1} to {2}", site, footerScriptProperty, footerScript), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
    testRunner.Given(string.Format("On {0} site I have prepared {1} content page", site, page), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
    testRunner.Given(string.Format("On {0} {1} I set the value of {2} property to {3}", site, page, pageScriptProperty, pageScript), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 32
    testRunner.When("I go to that page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
    testRunner.Then(string.Format("The JavaScript code {0} should return string value: {1}", verificationScript, verificationValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Mixed scripts checks")]
        [NUnit.Framework.TestCaseAttribute("SANDBOX", "SitewideHeaderScriptPlaceholder", "<script>window.customScriptVariable = 1;</script>", "SitewideFooterScriptPlaceholder", "<script>window.customScriptVariable++;</script>", "ScriptPlaceholder", "<script>window.customScriptVariable++;</script>", "/custom-scripts/content-page", "return window.customScriptVariable.toString();", "3", null)]
        public virtual void MixedScriptsChecks(string site, string headerScriptProperty, string headerScript, string footerScriptProperty, string footerScript, string pageScriptProperty, string pageScript, string page, string verificationScript, string verificationValue, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Mixed scripts checks", exampleTags);
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
    testRunner.Given(string.Format("On the {0} homepage I set the value of {1} to {2}", site, headerScriptProperty, headerScript), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
    testRunner.Given(string.Format("On the {0} homepage I set the value of {1} to {2}", site, footerScriptProperty, footerScript), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 42
    testRunner.Given(string.Format("On {0} site I have prepared {1} content page", site, page), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 43
    testRunner.Given(string.Format("On {0} {1} I set the value of {2} property to {3}", site, page, pageScriptProperty, pageScript), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
    testRunner.When("I go to that page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
    testRunner.Then(string.Format("The JavaScript code {0} should return string value: {1}", verificationScript, verificationValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
