using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecAid.ColumnActions;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecAid.SpecFlowTests
{
    [Binding]
    [Scope(Tag = "TypeConvertionTestsSteps")]
    public class TypeConvertionTestsSteps
    {
        private List<EveryThingObject> allEverything = new List<EveryThingObject>();

        [Given(@"I have EveryThing Objects")]
        public void GivenIHaveEveryThingObjects(Table table)
        {
            TableAid.ObjectCreator<EveryThingObject>(table, (tr, o) => { allEverything.Add(o); });
        }

        [Then(@"There are EveryThing Objects")]
        public void ThenThereAreEveryThingObjects(Table table)
        {
            TableAid.ObjectComparer<EveryThingObject>(table, allEverything);
        }

    }

    public class EveryThingObject
    {
        public Guid aGuid { get; set; }
        public int aInt { get; set; }
    }
}
