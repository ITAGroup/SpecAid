
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid;
using SpecAidGitHubSamples.Common;
using SpecAidGitHubSamples.Vaporware.Entities;
using SpecAidGitHubSamples.Vaporware.Repos;
using TechTalk.SpecFlow;

namespace SpecAidGitHubSamples.JackAndJill
{
    [Binding]
    [Scope(Tag = "JackAndJillBptStyleSteps")]
    public class JackAndJillBptStyleSteps
    {
        [Given(@"I have people")]
        public void GivenIHavePeople(Table table)
        {
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();
            TableAid.ObjectCreator<Person>(table, (tr, p) => peopleRepo.Save(p));
        }

        [When(@"'(.*)' goes up the hill")]
        public void WhenGoesUpTheHill(string personTag)
        {
            var person = FieldAid.ObjectCreator<Person>(personTag);
            person.Address = "Top of Hill";
        }

        [Then(@"There are people")]
        public void ThenThereArePeople(Table table)
        {
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();
            var people = peopleRepo.GetAll();
            TableAid.ObjectComparer(table,people);
        }


    }
}
