using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid;
using SpecAid.Helper;
using TechTalk.SpecFlow;

namespace SpecAidTests.TagTests
{
    [Binding]
    [Scope(Tag = "TagConvertionTestSteps")]
    public class TagConvertionTestSteps
    {
        private const string TheTagTag = "theTag";

        [Given(@"Tag '(.*)'")]
        public void GivenTag(string tag)
        {
            RecallAid.It[TheTagTag] = tag;
        }

        [When(@"Tag Is Normalized")]
        public void WhenTagIsNormalized()
        {
            var tag = (string)RecallAid.It[TheTagTag];
            var normalizedTag = TagHelper.Normalizer(tag);
            RecallAid.It[TheTagTag] = normalizedTag;
        }

        [Then(@"Tag is '(.*)'")]
        public void ThenTagIs(string expectTag)
        {
            var actualTag = (string)RecallAid.It[TheTagTag];
            Assert.AreEqual(expectTag,actualTag);
        }
    }
}
