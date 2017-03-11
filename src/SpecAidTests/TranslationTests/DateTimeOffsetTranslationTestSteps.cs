using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid;
using TechTalk.SpecFlow;

namespace SpecAidTests.TranslationTests
{
    [Binding]
    public sealed class DateTimeOffsetTranslationTestSteps
    {
        [Given(@"I have cities")]
        public void GivenIHaveCities(Table table)
        {
            TableAid.ObjectCreator<City>(table);
        }

        [Then(@"'(.*)' looks like")]
        public void ThenLooksLike(string cityNameTag, Table table)
        {
            var city = (City) RecallAid.It[cityNameTag];

            var cities = new List<City>
            {
                city
            };

            TableAid.ObjectComparer(table, cities);
        }
        

    }


    public class City
    {
        public string Name { get; set; }
        public DateTimeOffset CurrentDateTimeOffset { get; set; }
        public DateTimeOffset? BarClosingTime { get; set; }
    }
}
