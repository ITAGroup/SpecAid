﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.17929
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SpecAidGitHubSamples.Tutorials
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class TutorialBasicFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "TutorialBasic.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Tutorial Basic", "In order to have good examples\r\nI want some feature files", ProgrammingLanguage.CSharp, new string[] {
                        "TutorialSteps"});
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Tutorial Basic")))
            {
                SpecAidGitHubSamples.Tutorials.TutorialBasicFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Making People Example Basic")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Tutorial Basic")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialGivenBasicSteps")]
        public virtual void MakingPeopleExampleBasic()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Making People Example Basic", new string[] {
                        "TutorialGivenBasicSteps"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Emp Id",
                        "First Name",
                        "Last Name"});
            table1.AddRow(new string[] {
                        "1",
                        "Fox",
                        "Smith"});
#line 8
 testRunner.Given("I have People", ((string)(null)), table1, "Given ");
#line 12
 testRunner.Then("Assert True", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Making People Example Foreach")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Tutorial Basic")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialGivenForeachSteps")]
        public virtual void MakingPeopleExampleForeach()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Making People Example Foreach", new string[] {
                        "TutorialGivenForeachSteps"});
#line 15
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Emp Id",
                        "First Name",
                        "Last Name"});
            table2.AddRow(new string[] {
                        "1",
                        "Fox",
                        "Smith"});
#line 16
 testRunner.Given("I have People", ((string)(null)), table2, "Given ");
#line 20
 testRunner.Then("Assert True", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Making People Example Use An Action")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Tutorial Basic")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialGivenUseAnActionSteps")]
        public virtual void MakingPeopleExampleUseAnAction()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Making People Example Use An Action", new string[] {
                        "TutorialGivenUseAnActionSteps"});
#line 23
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Emp Id",
                        "First Name",
                        "Last Name"});
            table3.AddRow(new string[] {
                        "1",
                        "Fox",
                        "Smith"});
#line 24
 testRunner.Given("I have People", ((string)(null)), table3, "Given ");
#line 28
 testRunner.Then("Assert True", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Updating People Example")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Tutorial Basic")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialGivenUseAnActionSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialUpdatingPeopleSteps")]
        public virtual void UpdatingPeopleExample()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Updating People Example", new string[] {
                        "TutorialGivenUseAnActionSteps",
                        "TutorialUpdatingPeopleSteps"});
#line 32
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Emp Id",
                        "First Name",
                        "Last Name"});
            table4.AddRow(new string[] {
                        "1",
                        "Fox",
                        "Smith"});
#line 33
 testRunner.Given("I have People", ((string)(null)), table4, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "!Emp Id",
                        "Last Name"});
            table5.AddRow(new string[] {
                        "1",
                        "Jones"});
#line 37
 testRunner.Given("I update People", ((string)(null)), table5, "Given ");
#line 41
 testRunner.Then("Assert True", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Updating People Example ReSave")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Tutorial Basic")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialGivenUseAnActionSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialUpdatingPeopleReSaveSteps")]
        public virtual void UpdatingPeopleExampleReSave()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Updating People Example ReSave", new string[] {
                        "TutorialGivenUseAnActionSteps",
                        "TutorialUpdatingPeopleReSaveSteps"});
#line 45
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Emp Id",
                        "First Name",
                        "Last Name"});
            table6.AddRow(new string[] {
                        "1",
                        "Fox",
                        "Smith"});
#line 46
 testRunner.Given("I have People", ((string)(null)), table6, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "!Emp Id",
                        "Last Name"});
            table7.AddRow(new string[] {
                        "1",
                        "Jones"});
#line 50
 testRunner.Given("I update People", ((string)(null)), table7, "Given ");
#line 54
 testRunner.Then("Assert True", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Compare People Example Good")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Tutorial Basic")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialGivenUseAnActionSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialComparePeopleGoodSteps")]
        public virtual void ComparePeopleExampleGood()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Compare People Example Good", new string[] {
                        "TutorialGivenUseAnActionSteps",
                        "TutorialComparePeopleGoodSteps"});
#line 58
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Emp Id",
                        "First Name",
                        "Last Name"});
            table8.AddRow(new string[] {
                        "1",
                        "Fox",
                        "Smith"});
#line 59
 testRunner.Given("I have People", ((string)(null)), table8, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "!Notes",
                        "Emp Id",
                        "First Name",
                        "Last Name"});
            table9.AddRow(new string[] {
                        "",
                        "1",
                        "Fox",
                        "Smith"});
#line 63
 testRunner.Then("There are People", ((string)(null)), table9, "Then ");
#line 67
 testRunner.Then("Assert True", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Compare People Example Bad")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Tutorial Basic")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialGivenUseAnActionSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialComparePeopleBadSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialUpdatingPeopleReSaveSteps")]
        public virtual void ComparePeopleExampleBad()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Compare People Example Bad", new string[] {
                        "TutorialGivenUseAnActionSteps",
                        "TutorialComparePeopleBadSteps",
                        "TutorialUpdatingPeopleReSaveSteps"});
#line 73
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Emp Id",
                        "First Name",
                        "Last Name"});
            table10.AddRow(new string[] {
                        "1",
                        "Fox",
                        "Smith"});
#line 74
 testRunner.Given("I have People", ((string)(null)), table10, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "!Emp Id",
                        "Last Name"});
            table11.AddRow(new string[] {
                        "1",
                        "Jones"});
#line 78
  testRunner.Given("I update People", ((string)(null)), table11, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "!Notes",
                        "Emp Id",
                        "First Name",
                        "Last Name"});
            table12.AddRow(new string[] {
                        "",
                        "1",
                        "Fox",
                        "Smith"});
#line 82
 testRunner.Then("There are People", ((string)(null)), table12, "Then ");
#line 86
 testRunner.Then("Assert True", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FieldAid Example")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Tutorial Basic")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialGivenUseAnActionSteps")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TutorialFieldAidExampleSteps")]
        public virtual void FieldAidExample()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("FieldAid Example", new string[] {
                        "TutorialGivenUseAnActionSteps",
                        "TutorialFieldAidExampleSteps"});
#line 90
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tag It",
                        "Emp Id",
                        "First Name",
                        "Last Name"});
            table13.AddRow(new string[] {
                        "<<Fox>>",
                        "1",
                        "Fox",
                        "Smith"});
#line 91
 testRunner.Given("I have People", ((string)(null)), table13, "Given ");
#line 95
 testRunner.Then("Verify \'<<Fox>>.FirstName\' is \'Fox\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 97
 testRunner.Then("Assert True", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion