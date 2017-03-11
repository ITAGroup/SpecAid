using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid;
using TechTalk.SpecFlow;

namespace SpecAidTests.TranslationTests
{
    [Binding]
    [Scope(Tag = "NullableEnumTranslationTestSteps")]
    public class NullableEnumTranslationTestSteps
    {
        [Given(@"I have celebrities")]
        public void GivenIHaveCelebrities(Table table)
        {
            TableAid.ObjectCreator<Celebrity>(table);
        }

        [Then(@"'(.*)' graduated from '(.*)'")]
        public void ThenGraduatedFrom(string lastNameTag, string universityName)
        {
            var celebrity = (Celebrity) RecallAid.It[lastNameTag];
            Assert.AreEqual(universityName, celebrity.AlmaMater.ToString());
        }

        [Then(@"'(.*)' did not graduate")]
        public void ThenDidNotGraduate(string lastNameTag)
        {
            var celebrity = (Celebrity) RecallAid.It[lastNameTag];
            Assert.IsNull(celebrity.AlmaMater);
        }

    }

    public class Celebrity
    {
        public string LastName { get; set; }
        public AlmaMater? AlmaMater { get; set; }
    }

    public enum AlmaMater
    {
        Iowa,
        IowaState
    }
}
