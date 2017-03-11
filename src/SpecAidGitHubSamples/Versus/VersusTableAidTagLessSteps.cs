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
    [Scope(Tag = "VersusTableAidStepsTagLess")]
    public class VersusTableAidStepsTagLess
    {
        [Given(@"I have Stores")]
        public void GivenIHaveStores(Table table)
        {
            var storeRepo = RecallAidHelper.GetReal<StoreRepo>();
            TableAid.ObjectCreator<Store>(table, (tr, s) => storeRepo.Save(s));
        }

        [Given(@"I have People")]
        public void GivenIHavePeopleExampleBasic(Table table)
        {
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();
            var storeRepo = RecallAidHelper.GetReal<StoreRepo>();

            // Tell TableAid to Ignore the Un-mappable column 
            // Necessary when SpecAidAssertWhenUnknownColumn is True

            TableAid.ObjectCreator<Person>(
                table, 
                (tr, p) => {
                        p.Store = storeRepo.GetById(Convert.ToInt32(tr["Store Id"]));
                        peopleRepo.Save(p);
                    },
                (new CreateColumnBuilder<Person>()).AddIgnore("Store Id").Out
            );
        }

        [Then(@"There are People")]
        public void ThenThereArePeople(Table table)
        {
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();

            var actualPeople = peopleRepo.GetAll();

            TableAid.ObjectComparer(table, actualPeople);
        }
    }
}

