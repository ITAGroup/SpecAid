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
namespace SpecAidTests.DynamicTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class SpecAidLinqTestingsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SpecAidLinq.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecAid Linq Testings", "", ProgrammingLanguage.CSharp, new string[] {
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "SpecAid Linq Testings")))
            {
                SpecAidTests.DynamicTests.SpecAidLinqTestingsFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Linq Math")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Linq Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void LinqMath()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Linq Math", ((string[])(null)));
#line 4
this.ScenarioSetup(scenarioInfo);
#line 5
    testRunner.Then("Do Expression for Int \'do(5 + 5)\' = \'10\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Linq Recall Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Linq Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void LinqRecallTest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Linq Recall Test", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
    testRunner.Given("Tag This \'15\' as \'<<fifteen>>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
    testRunner.Then("Do Expression for Int \'do((Recall[\"<<fifteen>>\"]))\' = \'15\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Linq Recall Add Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Linq Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void LinqRecallAddTest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Linq Recall Add Test", ((string[])(null)));
#line 12
this.ScenarioSetup(scenarioInfo);
#line 13
    testRunner.Given("Tag This \'15\' as \'<<fifteen>>\' As Int", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
    testRunner.Then("Do Expression for Int \'do(Int32(Recall[\"<<fifteen>>\"]) + 5)\' = \'20\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Linq Recall Convert Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Linq Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void LinqRecallConvertTest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Linq Recall Convert Test", ((string[])(null)));
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
    testRunner.Given("Tag This \'15\' as \'<<fifteen>>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
    testRunner.Then("Do Expression for Int \'do(Convert.ToInt32(Recall[\"<<fifteen>>\"]) + 5)\' = \'20\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Linq With Old Tag Replace")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Linq Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void LinqWithOldTagReplace()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Linq With Old Tag Replace", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
    testRunner.Given("Tag This \'15\' as \'<<fifteen>>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 25
    testRunner.Then("Do Expression for Int \'do({<<fifteen>>} + 5)\' = \'20\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Linq With New Tag Replace")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Linq Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void LinqWithNewTagReplace()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Linq With New Tag Replace", ((string[])(null)));
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
    testRunner.Given("Tag This \'15\' as \'#fifteen\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
    testRunner.Then("Do Expression for Int \'do({#fifteen} + 5)\' = \'20\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Linq nested")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Linq Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void LinqNested()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Linq nested", ((string[])(null)));
#line 32
this.ScenarioSetup(scenarioInfo);
#line 33
    testRunner.Given("Tag This \'15\' as \'#fifteen15\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
    testRunner.Then("Do Expression for Int \'#fifteen{do(10 + 5)}\' = \'15\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Linq dont break on a bad lookup")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Linq Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void LinqDontBreakOnABadLookup()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Linq dont break on a bad lookup", ((string[])(null)));
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
    testRunner.Then("Do Expression for String \'do(\"{#unbroken}\" + \"5\")\' = \'{#unbroken}5\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Linq Recall Aid Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Linq Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void LinqRecallAidTest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Linq Recall Aid Test", ((string[])(null)));
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
    testRunner.Given("Tag This \'Ben\' as \'<<firstName>>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 42
    testRunner.Given("Tag This \'Jerry\' as \'<<lastName>>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 43
    testRunner.Given("Tag This \'Food\' as \'#Food\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
    testRunner.Given("Tag This \'Truck\' as \'#Truck\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "!BrandName",
                        "Name",
                        "EmployeeCount"});
            table1.AddRow(new string[] {
                        "<<BenJerrys>>",
                        "Ben and Jerry\'s",
                        "10"});
            table1.AddRow(new string[] {
                        "<<Generic>>",
                        "Generic",
                        "1"});
            table1.AddRow(new string[] {
                        "<<Homemade>>",
                        "Homemade",
                        "0"});
            table1.AddRow(new string[] {
                        "<<FoodTruck>>",
                        "FoodTruck",
                        "3"});
#line 46
    testRunner.Given("I have BrandNames", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "EmployeeCount"});
            table2.AddRow(new string[] {
                        "Ben and Jerry\'s",
                        "10"});
            table2.AddRow(new string[] {
                        "Generic",
                        "1"});
            table2.AddRow(new string[] {
                        "Homemade",
                        "0"});
            table2.AddRow(new string[] {
                        "FoodTruck",
                        "3"});
#line 53
    testRunner.Then("BrandNames Tests", ((string)(null)), table2, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "EmployeeCount"});
            table3.AddRow(new string[] {
                        "do(StringAid[\"<<firstName>>\"] + \" and \" + StringAid[\"<<lastName>>\"] + \"\'s\")",
                        "do(5 + 5)"});
            table3.AddRow(new string[] {
                        "Generic",
                        "do(StringAid[\"<<Generic>>.EmployeeCount\"])"});
            table3.AddRow(new string[] {
                        "do(\"{<<Homemade>>.Name}\")",
                        "0"});
            table3.AddRow(new string[] {
                        "do(\"{#Food}{#Truck}\")",
                        "3"});
#line 60
    testRunner.Then("BrandNames Tests", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
