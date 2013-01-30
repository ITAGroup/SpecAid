using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecAid.SpecFlowTests
{
    [Binding]
    [Scope(Tag = "SpecAidTests")]
    public class SpecAidTestSetup
    {
        IList<BananaSplit> bananaSplits;
        IList<Toppings> toppings;
        IList<BrandName> brandNames;

        [Given(@"I have BrandNames")]
        public void GivenIHaveBrandNames(Table table)
        {
            TableAid.ObjectCreator<BrandName>
            (
                table,
                (r, p) =>
                {
                    RecallAid.It[r["!BrandName"]] = p;
                    if (brandNames == null)
                    {
                        brandNames = new List<BrandName>();
                    }
                    brandNames.Add(p);
                }
            );
        }


        [Given(@"I have IceCreams")]
        public void GivenIHaveIceCreams(Table table)
        {
            TableAid.ObjectCreator<IceCream>
            (
                table,
                (r, p) =>
                {
                    RecallAid.It[r["!IceCream"]] = p;
                }
            );
        }

        [Given(@"I have Bananas")]
        public void GivenIHaveBananas(Table table)
        {
            TableAid.ObjectCreator<Banana>
            (
                table,
                (r, p) =>
                {
                    RecallAid.It[r["!Banana"]] = p;
                }
            );
        }

        [Given(@"I have Toppings")]
        public void GivenIHaveToppings(Table table)
        {
            TableAid.ObjectCreator<Toppings>
            (
                table,
                (r, p) =>
                {
                    RecallAid.It[r["!Topping"]] = p;
                    if (toppings == null)
                    {
                        toppings = new List<Toppings>();
                    }
                    toppings.Add(p);
                }
            );
        }

        [Given(@"I have BananaSplits")]
        public void GivenIHaveBananaSplits(Table table)
        {
            TableAid.ObjectCreator<BananaSplit>
            (
                table,
                (r, p) =>
                {
                    RecallAid.It[r["!BananaSplit"]] = p;
                }
            );
        }


        [Given(@"I update BananaSplits")]
        public void GivenIUpdateBananaSplits(Table table)
        {
            TableAid.ObjectUpdater<BananaSplit>
            (
                table,
                (r) =>
                {
                    return (BananaSplit)RecallAid.It[r["!BananaSplit"]];
                }
            );
        }

        [Given(@"a ice cream shop has a list of BananaSplits")]
        public void GivenAIceCreamShopHasAListOfBananaSplits()
        {
            bananaSplits = new List<BananaSplit>();
            bananaSplits.Add(RecallAid.It["<<BananaSplit1>>"] as BananaSplit);
            bananaSplits.Add(RecallAid.It["<<BananaSplit2>>"] as BananaSplit);
            bananaSplits.Add(RecallAid.It["<<BananaSplit3>>"] as BananaSplit);
            bananaSplits.Add(RecallAid.It["<<BananaSplit4>>"] as BananaSplit);
        }

        [Given(@"All the IceCeam goes bad")]
        public void GivenAllTheIceCeamGoesBad()
        {
            foreach (var bananaSplit in bananaSplits)
            {
                bananaSplit.IceCream = null;
            }
        }

        [Then(@"There are '(.*)' BananaSplits are available to order")]
        public void ThenFlavorBananaSplits(string flavor, Table table)
        {
            var theSplits = bananaSplits.Where(x => x.IceCream.Flavor == flavor).ToList();
            TableAid.ObjectComparer<BananaSplit>(table, theSplits);
        }

        [Then(@"There are BananaSplits are available to order")]
        public void ThenBananaSplits(Table table)
        {
            TableAid.ObjectComparer<BananaSplit>(table, bananaSplits);
        }

        [Then(@"There are '(.*)' BananaSplits are available to order WILL ASSERT '(.*)'")]
        public void ThenThereAreBananaSplitsAreAvailableToOrderWILLASSERT(string flavor, string message, Table table)
        {
            var theSplits = bananaSplits.Where(x => x.IceCream.Flavor == flavor).ToList();

            try
            {
                TableAid.ObjectComparer<BananaSplit>(table, theSplits);
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains(message))
                    Assert.AreEqual(true,true);
                else
                    Assert.Fail(exception.Message,message);
                return;
            }

            Assert.Fail("I Assert... Not so much.");
        }

        [Then(@"There are BananaSplits are available to order WILL ASSERT '(.*)'")]
        public void ThenThereAreBananaSplitsAreAvailableToOrderWILLASSERT(string message, Table table)
        {
            try
            {
                TableAid.ObjectComparer<BananaSplit>(table, bananaSplits);
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains(message))
                    Assert.AreEqual(true, true);
                else
                    Assert.Fail(exception.Message, message);
                return;
            }

            Assert.Fail("I Assert... Not so much.");
        }

        [Then(@"BrandNames Tests")]
        public void ThenBrandNamesTests(Table table)
        {
            TableAid.ObjectComparer(table, brandNames);
        }

        [Then(@"There are Topping Choices '(.*)'")]
        public void ThenThereAreToppingChoices(string expectedToppings)
        {
            var nameOfToppings = toppings.Select(x => x.Name).ToList();
            FieldAid.ObjectComparer(nameOfToppings, expectedToppings);
        }

        [Then(@"Do Expression '(.*)' = '(.*)'")]
        public void ThenDoExpression(string expression, string expected)
        {
            var actual = FieldAid.ObjectCreator<int>(expression);
            
            FieldAid.ObjectComparer(actual, expected);
        }

        [Given(@"Tag This '(.*)' as '(.*)'")]
        public void GivenTagThis(string value, string tag)
        {
            RecallAid.It[tag] = value;
        }

        [Given(@"Tag This '(.*)' as '(.*)' As Int")]
        public void GivenTagThisAsAsInt(string value, string tag)
        {
            RecallAid.It[tag] = Convert.ToInt32(value);
        }

        [Then(@"There is Interfaced IceCream Available")]
        public void ThenThereIsInterfacedIceCreamAvailable(Table table)
        {
            var listWithInterfaces = new List<IBrandName>();
            listWithInterfaces.AddRange(brandNames);

            TableAid.ObjectComparer(table, listWithInterfaces);
        }

    }

    public class BananaSplit
    {
        public BananaSplit()
        {
            Banana = new Banana();
            IceCream = new IceCream();
        }

        public Banana Banana { get; set; }
        public IceCream IceCream { get; set; }
        public List<Toppings> Toppings { get; set; }
    }

    public class Banana
    {
        public string Color {get; set;}
    }

    public class Toppings
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }


    public class IceCream
    {
        public IceCream()
        {
            BrandName = new BrandName();
        }

        public string Flavor { get; set; }
        public BrandName BrandName { get; set; }
    }

    public class BrandName : IBrandName
    {
        public string Name { get; set; }
        public int EmployeeCount { get; set; }
    }

    public interface IBrandName:IBrand, ICompany
    {
    }

    public interface IBrand
    {
        string Name { get; set; }
    }

    public interface ICompany
    {
        int EmployeeCount { get; set; }
    }

    //public class IndustryCatalog
    //{
    //    public IBrandName Brand { get; set; }
    //}
}
