using System.Collections.Generic;
using SpecAid;
using TechTalk.SpecFlow;

namespace SpecAidTests.BasicTests
{
    [Binding]
    [Scope(Tag = "IndexerTestsSteps")]
    public class IndexerTestsSteps
    {
        private readonly List<Dictionary<string, string>> _stringStringDictionaryList = new List<Dictionary<string, string>>();
        private readonly List<Dictionary<int, string>> _intStringDictionaryList = new List<Dictionary<int, string>>();

        [Given(@"The String String Dictionary")]
        public void GivenTheStringStringDictionary(Table table)
        {
            TableAid.ObjectCreator<Dictionary<string, string>>(table, (tr, o) => { _stringStringDictionaryList.Add(o); });
        }

        [Then(@"The String String Dictionary")]
        public void ThenTheStringStringDictionary(Table table)
        {
            TableAid.ObjectComparer(table, _stringStringDictionaryList);
        }

        [Given(@"The Int String Dictionary")]
        public void GivenTheIntStringDictionary(Table table)
        {
            TableAid.ObjectCreator<Dictionary<string, string>>(table, (tr, o) => { _stringStringDictionaryList.Add(o); });
        }

        [Then(@"The Int String Dictionary")]
        public void ThenTheIntStringDictionary(Table table)
        {
            TableAid.ObjectComparer(table, _stringStringDictionaryList);
        }
    }
}
