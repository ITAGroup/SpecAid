using System.Collections.Generic;
using SpecAid;
using SpecAidTests.Vaporware;
using TechTalk.SpecFlow;

namespace SpecAidTests.BasicTests
{
    [Binding]
    [Scope(Tag = "TypeConvertionTestsSteps")]
    public class TypeConvertionTestsSteps
    {
        private readonly List<EveryThingObject> allEverything = new List<EveryThingObject>();

        [Given(@"There are EveryThing Objects")]
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
}
