using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAidGitHubSamples.Common;
using SpecAidGitHubSamples.Vaporware.Classes;
using SpecAidGitHubSamples.Vaporware.Entities;
using SpecAidGitHubSamples.Vaporware.Repos;
using TechTalk.SpecFlow;
using SpecAid;

namespace SpecAidGitHubSamples.Tutorials
{
    [Binding]
    [Scope(Tag = "TutorialSteps")]
    public class TutorialSteps
    {
        [Then(@"Assert True")]
        public void ThenAssertTrue()
        {
            Assert.AreEqual(true, true);
        }
    }

    [Binding]
    [Scope(Tag = "TutorialGivenBasicSteps")]
    public class TutorialGivenBasicSteps
    {
        [Given(@"I have People")]
        public void GivenIHavePeopleExampleBasic(Table table)
        {
            TableAid.ObjectCreator<Person>(table);
        }
    }

    [Binding]
    [Scope(Tag = "TutorialGivenForeachSteps")]
    public class TutorialGivenForeachSteps
    {
        [Given(@"I have People")]
        public void GivenIHavePeopleExampleBasic(Table table)
        {
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();

            var people = TableAid.ObjectCreator<Person>(table);

            foreach (var person in people)
            {
                peopleRepo.Save(person);
            }
        }
    }

    [Binding]
    [Scope(Tag = "TutorialGivenUseAnActionSteps")]
    public class TutorialGivenUseAnActionSteps
    {
        [Given(@"I have People")]
        public void GivenIHavePeopleExampleBasic(Table table)
        {
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();

            TableAid.ObjectCreator<Person>(table, (tr, p) => peopleRepo.Save(p));
        }
    }

    [Binding]
    [Scope(Tag = "TutorialUpdatingPeopleSteps")]
    public class TutorialUpdatingPeopleSteps
    {
        [Given(@"I update People")]
        public void GivenIUpdatePeople(Table table)
        {
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();

            TableAid.ObjectUpdater<Person>
            (
                table,
                (tr) =>
                {
                    return peopleRepo.GetById(tr["!Emp Id"]);
                }
            );
        }
    }

    [Binding]
    [Scope(Tag = "TutorialUpdatingPeopleReSaveSteps")]
    public class TutorialUpdatingPeopleReSaveSteps
    {
        [Given(@"I update People")]
        public void GivenIUpdatePeople(Table table)
        {
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();

            TableAid.ObjectUpdater<Person>
            (
                table,
                (tr) =>
                {
                    return peopleRepo.GetById(tr["!Emp Id"]);
                },
                (tr, p) =>
                {
                    peopleRepo.Save(p);
                }
            );
        }
    }

    [Binding]
    [Scope(Tag = "TutorialComparePeopleGoodSteps")]
    public class TutorialComparePeopleGoodSteps
    {
        [Then(@"There are People")]
        public void ThenThereArePeople(Table table)
        {
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();

            var actualPeople = peopleRepo.GetAll();

            TableAid.ObjectComparer(table, actualPeople);
        }
    }


    [Binding]
    [Scope(Tag = "TutorialComparePeopleBadSteps")]
    public class TutorialComparePeopleBadSteps
    {
        [Then(@"There are People")]
        public void ThenThereArePeople(Table table)
        {
            try
            {
                var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();

                var actualPeople = peopleRepo.GetAll();

                TableAid.ObjectComparer(table, actualPeople);
            }
            catch (Exception ex)
            {
                // We are good!
                return;                
            }

            Assert.Fail("An Exception was expected.");
        }
    }

    [Binding]
    [Scope(Tag = "TutorialFieldAidExampleSteps")]
    public class TutorialFieldAidExampleSteps
    {
        [Then(@"Verify '(.*)' is '(.*)'")]
        public void ThenVerifyIs(string actual, string expected)
        {
            var actualFirstName = FieldAid.ObjectCreator<string>(actual);

            FieldAid.ObjectComparer(actualFirstName, expected);
        }
    }

    [Binding]
    [Scope(Tag = "TutorialNoSpoonSteps")]
    public class TutorialNoSpoonSteps
    {
        [Given(@"I have a Person")]
        public void GivenIHaveAPerson(Table table)
        {
            var person = TableAid.ObjectCreatorOne<Person>(table);
            RecallAid.It["Person"] = person;
        }

        [Then(@"There is a Person")]
        public void ThenThereIsAPerson(Table table)
        {
            var person = (Person)RecallAid.It["Person"];

            TableAid.ObjectComparerOne(table, person);
        }
    }

    [Binding]
    [Scope(Tag = "TutorialStoresSteps")]
    public class TutorialStoresSteps
    {
        [Given(@"I have Stores")]
        public void GivenIHaveStores(Table table)
        {
            var storeRepo = RecallAidHelper.GetReal<StoreRepo>();

            TableAid.ObjectCreator<Store>(table, (tr, s) => storeRepo.Save(s));
        }
    }

    [Binding]
    [Scope(Tag = "TutorialSpacesForAllSteps")]
    public class TutorialSpacesForAllSteps
    {
        [When(@"I Build the Store Employee Report")]
        public void WhenIBuildTheStoreEmployeeReport()
        {
            var storeRepo = RecallAidHelper.GetReal<StoreRepo>();
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();

            var allStores = storeRepo.GetAll();
            var allPeople = peopleRepo.GetQueryible().OrderByDescending(p=>p.YearsOfService).ToList();

            var lineNumber = 0;

            var report = new List<ReportEntry>();
                                                                            //1234567890123456789012345678901234567890
            report.Add(new ReportEntry() { LineNumber = lineNumber++, Line = "Store                                   " });
            report.Add(new ReportEntry() { LineNumber = lineNumber++, Line = "  Employee              Years of Service" });
            report.Add(new ReportEntry() { LineNumber = lineNumber++, Line = "                                        " });

            foreach (var store in allStores)
            {
                report.Add(new ReportEntry() { LineNumber = lineNumber++, Line = store.Name.PadRight(40) });
                foreach (var person in allPeople)
                {
                    if (person.Store.StoreId != store.StoreId)
                        return;

                    var theLine = "  " + person.FirstName + " " + person.LastName;
                    var theLine39 = theLine.PadRight(39);
                    var theLine40 = theLine39 + person.YearsOfService;

                    report.Add(new ReportEntry() { LineNumber = lineNumber++, Line = theLine40 });
                }
            }

            RecallAid.It["StoreReport"] = report;
        }


        [Then(@"The Store Employee Report Shows")]
        public void ThenTheStoreEmployeeReportShows(Table table)
        {
            var report = (List<ReportEntry>)RecallAid.It["StoreReport"];

            TableAid.ObjectComparer(table,report);
        }

    }
}
