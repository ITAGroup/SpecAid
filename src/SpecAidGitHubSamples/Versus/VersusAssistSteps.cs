using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid.ColumnActions;
using SpecAidGitHubSamples.Common;
using SpecAidGitHubSamples.Vaporware.Classes;
using SpecAidGitHubSamples.Vaporware.Entities;
using SpecAidGitHubSamples.Vaporware.Repos;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecAid;

namespace SpecAidGitHubSamples.Versus
{
    [Binding]
    [Scope(Tag = "VersusAssistSteps")]
    public class VersusAssistSteps
    {
        [Given(@"I have Stores")]
        public void GivenIHaveStores(Table table)
        {
            var storeRepo = RecallAidHelper.GetReal<StoreRepo>();

            var stores = table.CreateSet<Store>();

            foreach (var store in stores)
            {
                storeRepo.Save(store);
            }
        }

        [Given(@"I have People")]
        public void GivenIHavePeopleExampleBasic(Table table)
        {
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();
            var storeRepo = RecallAidHelper.GetReal<StoreRepo>();

            var people = table.CreateSet<Person>().ToList();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                var store = storeRepo.GetById(table.Rows[i]["Store Id"]);
                people[i].Store = store;

                peopleRepo.Save(people[i]);
            }
        }

        [Then(@"There are People")]
        public void ThenThereArePeople(Table table)
        {
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();

            var actualPeople = peopleRepo.GetQueryible();

            table.CompareToSet(actualPeople);
        }

    }
}

