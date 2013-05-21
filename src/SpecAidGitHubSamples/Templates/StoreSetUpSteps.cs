using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecAid;
using SpecAidGitHubSamples.Common;
using SpecAidGitHubSamples.Vaporware.Entities;
using SpecAidGitHubSamples.Vaporware.Repos;
using TechTalk.SpecFlow;

namespace SpecAidGitHubSamples.Templates
{
    [Binding]
    public class StoreSetUpSteps
    {
        [Given(@"I have Stores")]
        public void GivenIHaveStores(Table table)
        {
            var storeRepo = RecallAidHelper.GetReal<StoreRepo>();

            TableAid.ObjectCreator<Store>(table, (tr, s) => storeRepo.Save(s));
        }
    }
}
