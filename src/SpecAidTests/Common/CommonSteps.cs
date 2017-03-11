using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid.Base;
using TechTalk.SpecFlow;

namespace SpecAidTests.Common
{
    [Binding]
    [Scope(Tag = "CommonSteps")]
    public class CommonSteps
    {
        [Given(@"SpecAid Setting UseHashTag is '(.*)'")]
        public void GivenSpecAidSettingUseHashTagIs(bool setting)
        {
            SpecAidSettings.UseHashTag = setting;
        }

        [Then(@"Assert True")]
        public void ThenAssertTrue()
        {
            Assert.AreEqual(true, true);
        }

    }
}
