﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18444
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SpecAidTests.TranslationTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class NullableEnumTranslationTestsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "NullableEnumTranslationTests.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "NullableEnumTranslationTests", "", ProgrammingLanguage.CSharp, new string[] {
                        "NullableEnumTranslationTestSteps"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "NullableEnumTranslationTests")))
            {
                SpecAidTests.TranslationTests.NullableEnumTranslationTestsFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify nullable enum works")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NullableEnumTranslationTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NullableEnumTranslationTestSteps")]
        public virtual void VerifyNullableEnumWorks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify nullable enum works", ((string[])(null)));
#line 4
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tag It",
                        "LastName",
                        "AlmaMater"});
            table1.AddRow(new string[] {
                        "<<Brokaw>>",
                        "Brokaw",
                        "Iowa"});
            table1.AddRow(new string[] {
                        "<<Carver>>",
                        "Carver",
                        "IowaState"});
            table1.AddRow(new string[] {
                        "<<Zuckerberg>>",
                        "Zuckerberg",
                        ""});
            table1.AddRow(new string[] {
                        "<<Rose>>",
                        "Rose",
                        "null"});
#line 5
 testRunner.Given("I have celebrities", ((string)(null)), table1, "Given ");
#line 11
 testRunner.Then("\'<<Brokaw>>\' graduated from \'Iowa\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
 testRunner.Then("\'<<Carver>>\' graduated from \'IowaState\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
 testRunner.Then("\'<<Zuckerberg>>\' did not graduate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.Then("\'<<Rose>>\' did not graduate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion