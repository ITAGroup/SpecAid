
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid;
using SpecAidGitHubSamples.Common;
using SpecAidGitHubSamples.Vaporware.Entities;
using SpecAidGitHubSamples.Vaporware.Repos;
using TechTalk.SpecFlow;

namespace SpecAidGitHubSamples.JackAndJill
{
    [Binding]
    [Scope(Tag = "JackAndJillBddStyleSteps")]
    public class JackAndJillBddStyleSteps
    {
        [Given(@"Jack and Jill are at the bottom of the hill")]
        public void GivenJackAndJillAreAtTheBottomOfTheHill()
        {
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();

            var jack = new Person()
                {
                    FirstName = "Jack",
                    Address = "Bottom of Hill"
                };

            var jill = new Person()
            {
                FirstName = "Jill",
                Address = "Bottom of Hill"
            };

            peopleRepo.Save(jack);
            peopleRepo.Save(jill);

            ScenarioContext.Current.Add("JackId", jack.Id);
            ScenarioContext.Current.Add("JillId", jill.Id);
        }

        [When(@"They go up the hill")]
        public void WhenTheyGoUpTheHill()
        {
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();

            var jackId = (int)ScenarioContext.Current["JackId"];
            var jack = peopleRepo.GetById(jackId);
            jack.Address = "Top of Hill";
            peopleRepo.Save(jack);

            var jillId = (int)ScenarioContext.Current["JillId"];
            var jill = peopleRepo.GetById(jillId);
            jill.Address = "Top of Hill";
            peopleRepo.Save(jack);
        }

        [Then(@"They are on the hill")]
        public void ThenTheyAreOnTheHill()
        {
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();

            var jackId = (int)ScenarioContext.Current["JackId"];
            var jack = peopleRepo.GetById(jackId);
            Assert.AreEqual(jack.Address, "Top of Hill");

            var jillId = (int)ScenarioContext.Current["JillId"];
            var jill = peopleRepo.GetById(jillId);
            Assert.AreEqual(jill.Address, "Top of Hill");

        }

    }
}
