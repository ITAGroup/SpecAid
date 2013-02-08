using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecAidGitHubSamples.SpecflowWiredUp
{
    [Binding]
    [Scope(Tag = "SpecflowWiredUpSteps")]
    public class SpecflowWiredUpSteps
    {
        [Then(@"Assert True")]
        public void ThenAssertTrue()
        {
            Assert.AreEqual(true, true);
        }
    }
}
