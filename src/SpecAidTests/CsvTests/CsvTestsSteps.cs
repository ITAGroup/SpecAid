using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid;
using SpecAid.Helper;
using TechTalk.SpecFlow;

namespace SpecAidTests.CsvTests
{
    [Binding]
    [Scope(Tag = "CsvTests")]
    public class CsvTests
    {
        private List<string> _theList;
        private string _theString;

        [Given(@"String '(.*)'")]
        public void GivenIHaveString(string theString)
        {
            _theList = CsvHelper.Split(theString);
        }

        [Then(@"List")]
        public void ThenIHaveList(Table table)
        {
            TableAid.ObjectComparerSorted(table,_theList);
        }

        [Given(@"String For Csv '(.*)'")]
        public void GivenStringForCsv(string theString)
        {
            _theString = CsvHelper.ToCsv(theString);
        }

        [Then(@"Safe Csv String '(.*)'")]
        public void ThenSafeCsvString(string expected)
        {
            Assert.AreEqual(expected,_theString);
        }

    }
}
