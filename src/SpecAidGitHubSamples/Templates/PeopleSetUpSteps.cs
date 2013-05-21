using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecAid;
using SpecAidGitHubSamples.Vaporware.Entities;
using TechTalk.SpecFlow;

namespace SpecAidGitHubSamples.Templates
{
    [Binding]
    public class PeopleSetUpSteps
    {
      
           [Given(@"I have People")]
           public void GivenIHavePeople(Table table)
           {
               TableAid.ObjectCreator<Person>(table);
           }
     
    }
}
