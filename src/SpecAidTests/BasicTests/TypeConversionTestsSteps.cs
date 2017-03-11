using System.Collections.Generic;
using SpecAid;
using SpecAidTests.Vaporware;
using TechTalk.SpecFlow;

namespace SpecAidTests.BasicTests
{
    [Binding]
    [Scope(Tag = "TypeConversionTestsSteps")]
    public class TypeConversionTestsSteps
    {
        private readonly List<EveryThingObject> _allEverything = new List<EveryThingObject>();

        [Given(@"There are EveryThing Objects")]
        public void GivenIHaveEveryThingObjects(Table table)
        {
            TableAid.ObjectCreator<EveryThingObject>(table, (tr, o) => { _allEverything.Add(o); });
        }

        [Then(@"There are EveryThing Objects")]
        public void ThenThereAreEveryThingObjects(Table table)
        {
            TableAid.ObjectComparer(table, _allEverything);
        }
    }
}
