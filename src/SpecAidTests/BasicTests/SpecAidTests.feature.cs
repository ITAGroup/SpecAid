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
namespace SpecAidTests.BasicTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class SpecAidTestingsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SpecAidTests.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecAid Testings", "", ProgrammingLanguage.CSharp, new string[] {
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "SpecAid Testings")))
            {
                SpecAidTests.BasicTests.SpecAidTestingsFeature.FeatureSetup(null);
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
#line 4
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
#line 5
 testRunner.Given("I have BrandNames", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "!IceCream",
                        "Flavor",
                        "BrandName"});
            table2.AddRow(new string[] {
                        "<<BJVanilla>>",
                        "Vanilla",
                        "<<BenJerrys>>"});
            table2.AddRow(new string[] {
                        "<<BJChocolate>>",
                        "Chocolate",
                        "<<BenJerrys>>"});
            table2.AddRow(new string[] {
                        "<<GenericVanilla>>",
                        "Vanilla",
                        "<<Generic>>"});
            table2.AddRow(new string[] {
                        "<<GenericChocolate>>",
                        "Chocolate",
                        "<<Generic>>"});
#line 11
 testRunner.Given("I have IceCreams", ((string)(null)), table2, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "!Banana",
                        "Color"});
            table3.AddRow(new string[] {
                        "<<Banana>>",
                        "Yellow"});
#line 18
 testRunner.Given("I have Bananas", ((string)(null)), table3, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "!Topping",
                        "Name"});
            table4.AddRow(new string[] {
                        "<<ToppingNuts>>",
                        "Nuts"});
            table4.AddRow(new string[] {
                        "<<ToppingChocolateSyrup>>",
                        "Chocolate Syrup"});
            table4.AddRow(new string[] {
                        "<<ToppingStrawberries>>",
                        "Strawberries"});
            table4.AddRow(new string[] {
                        "<<ToppingWhipCreamp>>",
                        "Whip cream"});
#line 22
 testRunner.Given("I have Toppings", ((string)(null)), table4, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "!BananaSplit",
                        "Banana",
                        "IceCream",
                        "Toppings"});
            table5.AddRow(new string[] {
                        "<<BananaSplit1>>",
                        "<<Banana>>",
                        "<<BJVanilla>>",
                        "[<<ToppingNuts>>,<<ToppingChocolateSyrup>>]"});
            table5.AddRow(new string[] {
                        "<<BananaSplit2>>",
                        "<<Banana>>",
                        "<<BJChocolate>>",
                        "null"});
            table5.AddRow(new string[] {
                        "<<BananaSplit3>>",
                        "<<Banana>>",
                        "<<GenericChocolate>>",
                        "null"});
            table5.AddRow(new string[] {
                        "<<BananaSplit4>>",
                        "<<Banana>>",
                        "<<GenericVanilla>>",
                        "null"});
#line 29
 testRunner.Given("I have BananaSplits", ((string)(null)), table5, "Given ");
#line 36
 testRunner.Given("a ice cream shop has a list of BananaSplits", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify column deep setting works")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void VerifyColumnDeepSettingWorks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify column deep setting works", ((string[])(null)));
#line 38
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "!BananaSplit",
                        "IceCream.Flavor",
                        "IceCream.BrandName"});
            table6.AddRow(new string[] {
                        "<<BananaSplit3>>",
                        "Vanilla",
                        "<<Homemade>>"});
#line 41
 testRunner.Given("I update BananaSplits", ((string)(null)), table6, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Banana.Color",
                        "IceCream.Flavor",
                        "IceCream.BrandName.Name"});
            table7.AddRow(new string[] {
                        "Yellow",
                        "Vanilla",
                        "Ben and Jerry\'s"});
            table7.AddRow(new string[] {
                        "Yellow",
                        "Vanilla",
                        "Generic"});
            table7.AddRow(new string[] {
                        "Yellow",
                        "Vanilla",
                        "Homemade"});
#line 45
 testRunner.Then("There are \'Vanilla\' BananaSplits are available to order", ((string)(null)), table7, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify column deep linking works")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void VerifyColumnDeepLinkingWorks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify column deep linking works", ((string[])(null)));
#line 51
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Banana.Color",
                        "IceCream.Flavor",
                        "IceCream.BrandName.Name"});
            table8.AddRow(new string[] {
                        "Yellow",
                        "Vanilla",
                        "Ben and Jerry\'s"});
            table8.AddRow(new string[] {
                        "Yellow",
                        "Vanilla",
                        "Generic"});
#line 53
 testRunner.Then("There are \'Vanilla\' BananaSplits are available to order", ((string)(null)), table8, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify field deep linking works")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void VerifyFieldDeepLinkingWorks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify field deep linking works", ((string[])(null)));
#line 58
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Banana.Color",
                        "IceCream.Flavor",
                        "IceCream.BrandName.Name"});
            table9.AddRow(new string[] {
                        "<<BananaSplit1>>.Banana.Color",
                        "<<BananaSplit1>>.IceCream.Flavor",
                        "<<BananaSplit1>>.IceCream.BrandName.Name"});
            table9.AddRow(new string[] {
                        "<<BananaSplit4>>.Banana.Color",
                        "<<BananaSplit4>>.IceCream.Flavor",
                        "<<BananaSplit4>>.IceCream.BrandName.Name"});
#line 59
 testRunner.Then("There are \'Vanilla\' BananaSplits are available to order", ((string)(null)), table9, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify Column Error")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void VerifyColumnError()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Column Error", ((string[])(null)));
#line 64
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Banana.Color",
                        "IceCream.Flavor",
                        "IceCream.BrandName.Name"});
            table10.AddRow(new string[] {
                        "Yellow",
                        "Vanilla",
                        "Ben and Jerry\'s"});
            table10.AddRow(new string[] {
                        "Yellow",
                        "Vanilla2",
                        "Generic"});
#line 67
 testRunner.Then("There are \'Vanilla\' BananaSplits are available to order WILL ASSERT \'Non-Match on" +
                    " Row E2\'", ((string)(null)), table10, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Banana.Color",
                        "IceCream.Flavor",
                        "IceCream.BrandName.Name"});
            table11.AddRow(new string[] {
                        "Yellow",
                        "Vanilla",
                        "Ben and Jerry\'s"});
            table11.AddRow(new string[] {
                        "Yellow",
                        "Vanilla2",
                        "Generic"});
#line 73
 testRunner.Then("There are \'Vanilla\' BananaSplits are available to order WILL ASSERT \'Expected \'Va" +
                    "nilla2\', Actual \'Vanilla\'\'", ((string)(null)), table11, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Banana.Color",
                        "IceCream.Flavor",
                        "IceCream.BrandName.Name"});
            table12.AddRow(new string[] {
                        "Yellow",
                        "Vanilla",
                        "Ben and Jerry\'s"});
            table12.AddRow(new string[] {
                        "Yellow",
                        "Vanilla2",
                        "Generic"});
#line 79
 testRunner.Then("There are \'Vanilla\' BananaSplits are available to order WILL ASSERT \'Flavor\'", ((string)(null)), table12, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify Missing Row")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void VerifyMissingRow()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Missing Row", ((string[])(null)));
#line 84
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Banana.Color",
                        "IceCream.Flavor",
                        "IceCream.BrandName.Name"});
            table13.AddRow(new string[] {
                        "Yellow",
                        "Vanilla",
                        "Ben and Jerry\'s"});
#line 86
 testRunner.Then("There are \'Vanilla\' BananaSplits are available to order WILL ASSERT \'Not Enough T" +
                    "able Rows\'", ((string)(null)), table13, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify Missing Data")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void VerifyMissingData()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Missing Data", ((string[])(null)));
#line 90
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Banana.Color",
                        "IceCream.Flavor",
                        "IceCream.BrandName.Name"});
            table14.AddRow(new string[] {
                        "Yellow",
                        "Vanilla",
                        "Ben and Jerry\'s"});
#line 92
 testRunner.Then("There are \'Waffles\' BananaSplits are available to order WILL ASSERT \'Not Enough D" +
                    "ata\'", ((string)(null)), table14, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify Missing Deap Link Null")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void VerifyMissingDeapLinkNull()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Missing Deap Link Null", ((string[])(null)));
#line 96
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 98
 testRunner.Given("All the IceCeam goes bad", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Banana.Color",
                        "IceCream.Flavor",
                        "IceCream.BrandName.Name"});
            table15.AddRow(new string[] {
                        "<<BananaSplit1>>.Banana.Color",
                        "<<BananaSplit1>>.IceCream.Flavor",
                        "<<BananaSplit1>>.IceCream.BrandName.Name"});
            table15.AddRow(new string[] {
                        "<<BananaSplit2>>.Banana.Color",
                        "<<BananaSplit2>>.IceCream.Flavor",
                        "<<BananaSplit2>>.IceCream.BrandName.Name"});
            table15.AddRow(new string[] {
                        "<<BananaSplit3>>.Banana.Color",
                        "<<BananaSplit3>>.IceCream.Flavor",
                        "<<BananaSplit3>>.IceCream.BrandName.Name"});
            table15.AddRow(new string[] {
                        "<<BananaSplit4>>.Banana.Color",
                        "<<BananaSplit4>>.IceCream.Flavor",
                        "<<BananaSplit4>>.IceCream.BrandName.Name"});
#line 100
 testRunner.Then("There are BananaSplits are available to order WILL ASSERT \'Property is null\'", ((string)(null)), table15, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify listing works")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void VerifyListingWorks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify listing works", ((string[])(null)));
#line 107
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "Banana.Color",
                        "IceCream.Flavor",
                        "IceCream.BrandName.Name",
                        "Toppings"});
            table16.AddRow(new string[] {
                        "Yellow",
                        "Vanilla",
                        "Ben and Jerry\'s",
                        "[<<ToppingNuts>>,<<ToppingChocolateSyrup>>]"});
            table16.AddRow(new string[] {
                        "Yellow",
                        "Vanilla",
                        "Generic",
                        "null"});
#line 109
 testRunner.Then("There are \'Vanilla\' BananaSplits are available to order", ((string)(null)), table16, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify ignore works")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void VerifyIgnoreWorks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify ignore works", ((string[])(null)));
#line 114
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "Banana.Color",
                        "IceCream.Flavor",
                        "IceCream.BrandName.Name",
                        "Toppings"});
            table17.AddRow(new string[] {
                        "Yellow",
                        "Vanilla",
                        "[ignore]",
                        "[ignore]"});
            table17.AddRow(new string[] {
                        "Yellow",
                        "Vanilla",
                        "Generic",
                        "null"});
#line 116
 testRunner.Then("There are \'Vanilla\' BananaSplits are available to order", ((string)(null)), table17, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Basic Lists")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void BasicLists()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Basic Lists", ((string[])(null)));
#line 121
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 123
 testRunner.Then("There are Topping Choices \'[Nuts,Chocolate Syrup,Strawberries,Whip cream]\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Basic List Compare Table Version")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void BasicListCompareTableVersion()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Basic List Compare Table Version", ((string[])(null)));
#line 125
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "This"});
            table18.AddRow(new string[] {
                        "Nuts"});
            table18.AddRow(new string[] {
                        "Chocolate Syrup"});
            table18.AddRow(new string[] {
                        "Strawberries"});
            table18.AddRow(new string[] {
                        "Whip cream"});
#line 126
 testRunner.Then("There are Topping Choices", ((string)(null)), table18, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Basic List Compare Table Version with Assert")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void BasicListCompareTableVersionWithAssert()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Basic List Compare Table Version with Assert", ((string[])(null)));
#line 133
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "This"});
            table19.AddRow(new string[] {
                        "Nuts2"});
            table19.AddRow(new string[] {
                        "Chocolate Syrup"});
            table19.AddRow(new string[] {
                        "Strawberries"});
            table19.AddRow(new string[] {
                        "Whip cream"});
#line 134
 testRunner.Then("There are Topping Choices WILL ASSERT \'Expected \'Nuts2\', Actual \'Nuts\'\'", ((string)(null)), table19, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Basic List Compare Sorted Table Version")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void BasicListCompareSortedTableVersion()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Basic List Compare Sorted Table Version", ((string[])(null)));
#line 141
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "This"});
            table20.AddRow(new string[] {
                        "Chocolate Syrup"});
            table20.AddRow(new string[] {
                        "Nuts"});
            table20.AddRow(new string[] {
                        "Strawberries"});
            table20.AddRow(new string[] {
                        "Whip cream"});
#line 142
 testRunner.Then("There are Sorted Topping Choices", ((string)(null)), table20, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Basic List Compare Sorted Table Version with Assert Out of Order")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void BasicListCompareSortedTableVersionWithAssertOutOfOrder()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Basic List Compare Sorted Table Version with Assert Out of Order", ((string[])(null)));
#line 149
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "This"});
            table21.AddRow(new string[] {
                        "Nuts"});
            table21.AddRow(new string[] {
                        "Chocolate Syrup"});
            table21.AddRow(new string[] {
                        "Strawberries"});
            table21.AddRow(new string[] {
                        "Whip cream"});
#line 150
 testRunner.Then("There are Sorted Topping Choices WILL ASSERT \'Expected \'Nuts\', Actual \'Chocolate " +
                    "Syrup\'\'", ((string)(null)), table21, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Basic List Compare Sorted Table Version with Assert Not Enough")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void BasicListCompareSortedTableVersionWithAssertNotEnough()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Basic List Compare Sorted Table Version with Assert Not Enough", ((string[])(null)));
#line 157
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "This"});
            table22.AddRow(new string[] {
                        "Chocolate Syrup"});
            table22.AddRow(new string[] {
                        "Nuts"});
            table22.AddRow(new string[] {
                        "Strawberries"});
#line 158
 testRunner.Then("There are Sorted Topping Choices WILL ASSERT \'Not Enough Table Rows.\'", ((string)(null)), table22, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Basic List Compare Sorted Table Version with Assert Too Many")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void BasicListCompareSortedTableVersionWithAssertTooMany()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Basic List Compare Sorted Table Version with Assert Too Many", ((string[])(null)));
#line 164
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                        "This"});
            table23.AddRow(new string[] {
                        "Chocolate Syrup"});
            table23.AddRow(new string[] {
                        "Nuts"});
            table23.AddRow(new string[] {
                        "Strawberries"});
            table23.AddRow(new string[] {
                        "Whip cream"});
            table23.AddRow(new string[] {
                        "Sprinkles"});
#line 165
 testRunner.Then("There are Sorted Topping Choices WILL ASSERT \'Not Enough Data.\'", ((string)(null)), table23, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Sick Lists")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void SickLists()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sick Lists", ((string[])(null)));
#line 173
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 175
 testRunner.Then("There are Topping Choices \'[<<ToppingNuts>>.Name,Chocolate Syrup,Strawberries,Whi" +
                    "p cream]\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify nested interfaces work")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void VerifyNestedInterfacesWork()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify nested interfaces work", ((string[])(null)));
#line 177
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "EmployeeCount"});
            table24.AddRow(new string[] {
                        "Ben and Jerry\'s",
                        "10"});
            table24.AddRow(new string[] {
                        "Generic",
                        "1"});
            table24.AddRow(new string[] {
                        "Homemade",
                        "0"});
#line 179
 testRunner.Then("There is Interfaced IceCream Available", ((string)(null)), table24, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Then Tagging Works")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void ThenTaggingWorks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Then Tagging Works", ((string[])(null)));
#line 185
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tag It",
                        "Banana.Color",
                        "IceCream.Flavor",
                        "IceCream.BrandName.Name"});
            table25.AddRow(new string[] {
                        "<<VanillaBen>>",
                        "Yellow",
                        "Vanilla",
                        "Ben and Jerry\'s"});
            table25.AddRow(new string[] {
                        "<<VanillaGeneric>>",
                        "Yellow",
                        "Vanilla",
                        "Generic"});
#line 187
 testRunner.Then("There are \'Vanilla\' BananaSplits are available to order", ((string)(null)), table25, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table26.AddRow(new string[] {
                        "Banana.Color",
                        "Yellow"});
            table26.AddRow(new string[] {
                        "IceCream.Flavor",
                        "Vanilla"});
#line 192
    testRunner.Then("BananaSplit \'<<VanillaBen>>\' looks like", ((string)(null)), table26, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Then Symbolics Works")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecAid Testings")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SpecAidTests")]
        public virtual void ThenSymbolicsWorks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Then Symbolics Works", ((string[])(null)));
#line 197
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                        "IceCream Flavor",
                        "Brand of Ice Cream"});
            table27.AddRow(new string[] {
                        "Vanilla",
                        "Ben and Jerry\'s"});
            table27.AddRow(new string[] {
                        "Vanilla",
                        "Generic"});
#line 198
 testRunner.Then("\'Vanilla\' BananaSplits on the menu", ((string)(null)), table27, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
