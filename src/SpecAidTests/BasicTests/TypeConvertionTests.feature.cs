﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34014
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SpecAidTests.BasicTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class TypeConvertionTestsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "TypeConvertionTests.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "TypeConvertionTests", "", ProgrammingLanguage.CSharp, new string[] {
                        "TypeConvertionTestsSteps"});
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "TypeConvertionTests")))
            {
                SpecAidTests.BasicTests.TypeConvertionTestsFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TypeConvertionTests - Int")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TypeConvertionTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TypeConvertionTestsSteps")]
        public virtual void TypeConvertionTests_Int()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TypeConvertionTests - Int", ((string[])(null)));
#line 4
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "anInt"});
            table1.AddRow(new string[] {
                        "12"});
#line 5
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "anInt"});
            table2.AddRow(new string[] {
                        "12"});
#line 9
 testRunner.Then("There are EveryThing Objects", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TypeConvertionTests - Guid")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TypeConvertionTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TypeConvertionTestsSteps")]
        public virtual void TypeConvertionTests_Guid()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TypeConvertionTests - Guid", ((string[])(null)));
#line 13
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "aGuid"});
            table3.AddRow(new string[] {
                        "11ab0769-41cb-4655-b05d-621cc17585d4"});
#line 14
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table3, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "aGuid"});
            table4.AddRow(new string[] {
                        "11ab0769-41cb-4655-b05d-621cc17585d4"});
#line 18
 testRunner.Then("There are EveryThing Objects", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TypeConvertionTests - Nullable Guid")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TypeConvertionTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TypeConvertionTestsSteps")]
        public virtual void TypeConvertionTests_NullableGuid()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TypeConvertionTests - Nullable Guid", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "aNullableGuid"});
            table5.AddRow(new string[] {
                        "11ab0769-41cb-4655-b05d-621cc17585d4"});
            table5.AddRow(new string[] {
                        "null"});
#line 23
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table5, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "aNullableGuid"});
            table6.AddRow(new string[] {
                        "11ab0769-41cb-4655-b05d-621cc17585d4"});
            table6.AddRow(new string[] {
                        "null"});
#line 28
 testRunner.Then("There are EveryThing Objects", ((string)(null)), table6, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TypeConvertionTests - Enumerable")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TypeConvertionTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TypeConvertionTestsSteps")]
        public virtual void TypeConvertionTests_Enumerable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TypeConvertionTests - Enumerable", ((string[])(null)));
#line 33
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "someStrings"});
            table7.AddRow(new string[] {
                        "[a,b,c]"});
#line 34
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table7, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "someStrings"});
            table8.AddRow(new string[] {
                        "[a,b,c]"});
#line 38
 testRunner.Then("There are EveryThing Objects", ((string)(null)), table8, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TypeConvertionTests - Enumerable No Brackets")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TypeConvertionTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TypeConvertionTestsSteps")]
        public virtual void TypeConvertionTests_EnumerableNoBrackets()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TypeConvertionTests - Enumerable No Brackets", ((string[])(null)));
#line 42
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "someStrings"});
            table9.AddRow(new string[] {
                        "a,b,c"});
#line 43
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table9, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "someStrings"});
            table10.AddRow(new string[] {
                        "a,b,c"});
#line 47
 testRunner.Then("There are EveryThing Objects", ((string)(null)), table10, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TypeConvertionTests - Enumerable Null")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TypeConvertionTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TypeConvertionTestsSteps")]
        public virtual void TypeConvertionTests_EnumerableNull()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TypeConvertionTests - Enumerable Null", ((string[])(null)));
#line 51
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "someStrings"});
            table11.AddRow(new string[] {
                        "null"});
#line 52
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table11, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "someStrings"});
            table12.AddRow(new string[] {
                        "null"});
#line 56
 testRunner.Then("There are EveryThing Objects", ((string)(null)), table12, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TypeConvertionTests - List")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TypeConvertionTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TypeConvertionTestsSteps")]
        public virtual void TypeConvertionTests_List()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TypeConvertionTests - List", ((string[])(null)));
#line 60
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "ListStrings"});
            table13.AddRow(new string[] {
                        "[a,b,c]"});
#line 61
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table13, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "ListStrings"});
            table14.AddRow(new string[] {
                        "[a,b,c]"});
#line 65
 testRunner.Then("There are EveryThing Objects", ((string)(null)), table14, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TypeConvertionTests - List Null")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TypeConvertionTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TypeConvertionTestsSteps")]
        public virtual void TypeConvertionTests_ListNull()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TypeConvertionTests - List Null", ((string[])(null)));
#line 69
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "ListStrings"});
            table15.AddRow(new string[] {
                        "null"});
#line 70
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table15, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "ListStrings"});
            table16.AddRow(new string[] {
                        "null"});
#line 74
 testRunner.Then("There are EveryThing Objects", ((string)(null)), table16, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TypeConvertionTests - PlainList")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TypeConvertionTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TypeConvertionTestsSteps")]
        public virtual void TypeConvertionTests_PlainList()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TypeConvertionTests - PlainList", ((string[])(null)));
#line 78
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "PlainList"});
            table17.AddRow(new string[] {
                        "[a,b,c]"});
#line 79
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table17, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "PlainList"});
            table18.AddRow(new string[] {
                        "[a,b,c]"});
#line 83
 testRunner.Then("There are EveryThing Objects", ((string)(null)), table18, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TypeConvertionTests - PlainList Null")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TypeConvertionTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TypeConvertionTestsSteps")]
        public virtual void TypeConvertionTests_PlainListNull()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TypeConvertionTests - PlainList Null", ((string[])(null)));
#line 87
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "PlainList"});
            table19.AddRow(new string[] {
                        "null"});
#line 88
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table19, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "PlainList"});
            table20.AddRow(new string[] {
                        "null"});
#line 92
 testRunner.Then("There are EveryThing Objects", ((string)(null)), table20, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TypeConvertionTests - Array")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TypeConvertionTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TypeConvertionTestsSteps")]
        public virtual void TypeConvertionTests_Array()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TypeConvertionTests - Array", ((string[])(null)));
#line 96
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "ArrayStrings"});
            table21.AddRow(new string[] {
                        "[a,b,c]"});
#line 97
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table21, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "ArrayStrings"});
            table22.AddRow(new string[] {
                        "[a,b,c]"});
#line 101
 testRunner.Then("There are EveryThing Objects", ((string)(null)), table22, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TypeConvertionTests - Array Null")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "TypeConvertionTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TypeConvertionTestsSteps")]
        public virtual void TypeConvertionTests_ArrayNull()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TypeConvertionTests - Array Null", ((string[])(null)));
#line 105
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                        "ArrayStrings"});
            table23.AddRow(new string[] {
                        "null"});
#line 106
 testRunner.Given("There are EveryThing Objects", ((string)(null)), table23, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                        "ArrayStrings"});
            table24.AddRow(new string[] {
                        "null"});
#line 110
 testRunner.Then("There are EveryThing Objects", ((string)(null)), table24, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
