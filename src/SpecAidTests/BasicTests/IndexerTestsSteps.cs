using System.Collections.Generic;
using SpecAid;
using TechTalk.SpecFlow;

namespace SpecAidTests.BasicTests
{
    public class ComplexIndexerObject
    {
        private readonly Dictionary<int,string> _ints = new Dictionary<int,string>();
        private readonly Dictionary<string, string> _strings = new Dictionary<string, string>();

        public string this[int i]
        {
            get { return _ints[i]; }
            set { _ints[i] = value; }
        }

        public string this[string i]
        {
            get { return _strings[i]; }
            set { _strings[i] = value; }
        }

        public int CountOfIntLookups
        {
            get { return _ints.Count; }
            set { }
        }

        public int CountOfStringLookups
        {
            get { return _ints.Count; }
            set { }
        }
    }

    [Binding]
    [Scope(Tag = "IndexerTestsSteps")]
    public class IndexerTestsSteps
    {
        private readonly List<Dictionary<string, string>> _stringStringDictionaryList = new List<Dictionary<string, string>>();
        private readonly List<Dictionary<int, string>> _intStringDictionaryList = new List<Dictionary<int, string>>();
        private readonly List<ComplexIndexerObject> _complexIndexerObjects = new List<ComplexIndexerObject>();

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
            TableAid.ObjectCreator<Dictionary<int, string>>(table, (tr, o) => { _intStringDictionaryList.Add(o); });
        }

        [Then(@"The Int String Dictionary")]
        public void ThenTheIntStringDictionary(Table table)
        {
            TableAid.ObjectComparer(table, _intStringDictionaryList);
        }

        [Given(@"The Complex Indexer Object")]
        public void GivenTheComplexIndexerObject(Table table)
        {
            TableAid.ObjectCreator<ComplexIndexerObject>(table, (tr, o) => { _complexIndexerObjects.Add(o); });
        }

        [Then(@"The Complex Indexer Object")]
        public void ThenTheComplexIndexerObject(Table table)
        {
            TableAid.ObjectComparer(table, _complexIndexerObjects);
        }
    }
}
