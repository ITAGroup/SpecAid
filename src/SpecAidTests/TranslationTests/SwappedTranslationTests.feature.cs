﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
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
    public partial class SwappedTranslationTestsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SwappedTranslationTests.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SwappedTranslationTests", "", ProgrammingLanguage.CSharp, new string[] {
                        "CommonSteps",
                        "LookupTestsSteps",
                        "SpecAidTests"});
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "SwappedTranslationTests")))
            {
                SpecAidTests.TranslationTests.SwappedTranslationTestsFeature.FeatureSetup(null);
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
        
        public virtual void FeatureBackground()
        {
#line 6
#line 7
 testRunner.Given("SpecAid Setting UseHashTag is \'true\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("SwappedTranslationTests - UseHashTag True Hash Changes")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SwappedTranslationTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CommonSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("LookupTestsSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void SwappedTranslationTests_UseHashTagTrueHashChanges()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SwappedTranslationTests - UseHashTag True Hash Changes", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 10
 testRunner.Given("Tag This \'Some\' as \'#Some\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.Given("Tag This \'big\' as \'#Big\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
 testRunner.Given("Tag This \'string\' as \'#String\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tag It",
                        "AString"});
            table1.AddRow(new string[] {
                        "#Everything",
                        "Some big string"});
#line 14
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "!LookUp",
                        "AString"});
            table2.AddRow(new string[] {
                        "#Everything",
                        "{#Some} {#Big} {#String}"});
#line 18
 testRunner.Then("There are EveryThing Objects via Lookup", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("SwappedTranslationTests String Building")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SwappedTranslationTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CommonSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("LookupTestsSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void SwappedTranslationTestsStringBuilding()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SwappedTranslationTests String Building", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 23
 testRunner.Given("Tag This \'Some\' as \'#Some\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.Given("Tag This \'big\' as \'#Big\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 25
 testRunner.Given("Tag This \'string\' as \'#String\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tag It",
                        "AString"});
            table3.AddRow(new string[] {
                        "#Everything",
                        "Some big string"});
#line 27
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table3, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "!LookUp",
                        "AString"});
            table4.AddRow(new string[] {
                        "#Everything",
                        "{#Some} {#Big} {#String}"});
#line 31
 testRunner.Then("There are EveryThing Objects via Lookup", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("SwappedTranslationTests Generated Keys")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SwappedTranslationTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CommonSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("LookupTestsSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void SwappedTranslationTestsGeneratedKeys()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SwappedTranslationTests Generated Keys", ((string[])(null)));
#line 35
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tag It",
                        "AString"});
            table5.AddRow(new string[] {
                        "#Everything",
                        "AString"});
#line 36
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table5, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "!LookUp",
                        "MyErrorMessage"});
            table6.AddRow(new string[] {
                        "#Everything",
                        "Everything Object with Id {#Everything.Id} message."});
#line 40
 testRunner.Then("There are EveryThing Objects via Lookup", ((string)(null)), table6, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("SwappedTranslationTests Nested String Building")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SwappedTranslationTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CommonSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("LookupTestsSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void SwappedTranslationTestsNestedStringBuilding()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SwappedTranslationTests Nested String Building", ((string[])(null)));
#line 44
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 45
 testRunner.Given("Tag This \'SomeBigString\' as \'#SomeBigString\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
 testRunner.Given("Tag This \'BigString\' as \'#BigString\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 47
 testRunner.Given("Tag This \'String\' as \'#String\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tag It",
                        "AString"});
            table7.AddRow(new string[] {
                        "#Everything",
                        "SomeBigString"});
#line 49
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table7, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "!LookUp",
                        "AString"});
            table8.AddRow(new string[] {
                        "#Everything",
                        "#Some{#Big{#String}}"});
#line 53
 testRunner.Then("There are EveryThing Objects via Lookup", ((string)(null)), table8, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("SwappedTranslationTests Swap Linq")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SwappedTranslationTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CommonSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("LookupTestsSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void SwappedTranslationTestsSwapLinq()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SwappedTranslationTests Swap Linq", ((string[])(null)));
#line 57
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 58
 testRunner.Given("Tag This \'do(5 + 5)\' as \'#linq\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tag It",
                        "AString"});
            table9.AddRow(new string[] {
                        "#Everything",
                        "10"});
#line 60
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table9, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "!LookUp",
                        "AString"});
            table10.AddRow(new string[] {
                        "#Everything",
                        "{#linq}"});
#line 64
 testRunner.Then("There are EveryThing Objects via Lookup", ((string)(null)), table10, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("SwappedTranslationTests Text Does not Have to Swap")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SwappedTranslationTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CommonSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("LookupTestsSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void SwappedTranslationTestsTextDoesNotHaveToSwap()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SwappedTranslationTests Text Does not Have to Swap", ((string[])(null)));
#line 68
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tag It",
                        "AString"});
            table11.AddRow(new string[] {
                        "#Everything",
                        "\"{AString}\""});
#line 69
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table11, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "!LookUp",
                        "AString"});
            table12.AddRow(new string[] {
                        "#Everything",
                        "{AString}"});
#line 73
 testRunner.Then("There are EveryThing Objects via Lookup", ((string)(null)), table12, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("SwappedTranslationTests Swap Array")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SwappedTranslationTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CommonSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("LookupTestsSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void SwappedTranslationTestsSwapArray()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SwappedTranslationTests Swap Array", ((string[])(null)));
#line 77
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 78
 testRunner.Given("Tag This \'Some\' as \'#Some\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 79
 testRunner.Given("Tag This \'Big\' as \'#Big\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 80
 testRunner.Given("Tag This \'String\' as \'#String\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tag It",
                        "ArrayStrings"});
            table13.AddRow(new string[] {
                        "#Everything",
                        "[{#Some},{#Big},{#String}]"});
#line 82
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table13, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "!LookUp",
                        "ArrayStrings"});
            table14.AddRow(new string[] {
                        "#Everything",
                        "[Some,Big,String]"});
#line 86
 testRunner.Then("There are EveryThing Objects via Lookup", ((string)(null)), table14, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("SwappedTranslationTests Swap List")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SwappedTranslationTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CommonSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("LookupTestsSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void SwappedTranslationTestsSwapList()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SwappedTranslationTests Swap List", ((string[])(null)));
#line 90
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 91
 testRunner.Given("Tag This \'Some\' as \'#Some\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 92
 testRunner.Given("Tag This \'Big\' as \'#Big\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 93
 testRunner.Given("Tag This \'String\' as \'#String\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tag It",
                        "SomeStrings"});
            table15.AddRow(new string[] {
                        "#Everything",
                        "[{#Some},{#Big},{#String}]"});
#line 95
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table15, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "!LookUp",
                        "SomeStrings"});
            table16.AddRow(new string[] {
                        "#Everything",
                        "[Some,Big,String]"});
#line 99
 testRunner.Then("There are EveryThing Objects via Lookup", ((string)(null)), table16, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
