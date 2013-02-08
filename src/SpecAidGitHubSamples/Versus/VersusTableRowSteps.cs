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
    [Scope(Tag = "VersusTableRowSteps")]
    public class VersusTableRowSteps
    {
        [Given(@"I have Stores")]
        public void GivenIHaveStores(Table table)
        {
            var storeRepo = RecallAidHelper.GetReal<StoreRepo>();

            foreach (var tableRow in table.Rows)
            {
                var newStore = new Store();

                newStore.StoreId = int.Parse(tableRow["Store Id"]);
                newStore.Name = tableRow["Name"];

                storeRepo.Save(newStore);
            }
        }


        [Given(@"I have People")]
        public void GivenIHavePeople(Table table)
        {
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();
            var storeRepo = RecallAidHelper.GetReal<StoreRepo>();

            foreach (var tableRow in table.Rows)
            {
                var localTableRow = tableRow;

                var newPerson = new Person();

                newPerson.EmpId = tableRow["Emp Id"];
                newPerson.FirstName = tableRow["First Name"];
                newPerson.MiddleName = tableRow["Middle Name"];
                newPerson.LastName = tableRow["Last Name"];
                newPerson.YearsOfService = int.Parse(tableRow["Years Of Service"]);

                var store = storeRepo.GetById(localTableRow["Store Id"]);

                newPerson.Store = store;

                peopleRepo.Save(newPerson);
            }
        }

        [Then(@"There are People")]
        public void ThenThereArePeople(Table table)
        {
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();

            foreach (var tableRow in table.Rows)
            {
                var person = peopleRepo.GetById(tableRow["Emp Id"]);

                if (person == null)
                    Assert.Fail("Person not found");

                Assert.AreEqual(tableRow["First Name"],person.FirstName);
                Assert.AreEqual(tableRow["Middle Name"],person.MiddleName);
                Assert.AreEqual(tableRow["Last Name"],person.LastName);
                Assert.AreEqual(int.Parse(tableRow["Years Of Service"]),person.YearsOfService);

                Assert.AreEqual(tableRow["Store.Name"],person.Store.Name);
            }
        }
    }
}

