using SpecAid.Base;
using TechTalk.SpecFlow;

namespace SpecAidTests.Common
{
    [Binding]
    public class SetupSteps
    {
        [Before]
        public void Before()
        {
            SpecAidSettings.UseHashTag = true;
            SpecAidSettings.AssertWhenUnknownColumn = true;
        }
    }
}