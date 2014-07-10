using SpecAid;
using SpecAidTests.Vaporware;
using TechTalk.SpecFlow;

namespace SpecAidTests.TagTests
{
    [Binding]
    [Scope(Tag = "LookupTestsSteps")]
    public class LookupTestsSteps
    {
        [Given(@"There are EveryThing Objects")]
        public void GivenIHaveEveryThingObjects(Table table)
        {
            TableAid.ObjectCreator<EveryThingObject>(table);
        }

        [Then(@"There are EveryThing Objects via Lookup")]
        public void ThenThereAreEveryThingObjects(Table table)
        {
            TableAid.ObjectComparer(
                table,
                (row) =>
                {
                    if (row.ContainsKey("!LookUp"))
                    {
                        var tag = row["!LookUp"];
                        return (EveryThingObject)RecallAid.It[tag];
                    }
                    return null;
                });
        }

        [Then(@"There are EveryThing Objects via Recall")]
        public void ThenThereAreEveryThingObjectsViaRecall(Table table)
        {
            TableAid.ObjectComparerRecall<EveryThingObject>(table);
        }
    }
}
