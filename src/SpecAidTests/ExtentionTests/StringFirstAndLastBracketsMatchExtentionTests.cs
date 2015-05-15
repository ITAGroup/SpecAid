using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid.Extentions;

namespace SpecAidTests.ExtentionTests
{
    [TestClass]
    public class StringFirstAndLastBracketsMatchExtentionTests
    {
        [TestMethod]
        public void MatchedWithEnd()
        {
            Assert.AreEqual(true,"{}".FirstAndLastBracketsMatch('{','}'));
        }

        [TestMethod]
        public void MissingStart()
        {
            Assert.AreEqual(false, "}".FirstAndLastBracketsMatch('{', '}'));
        }

        [TestMethod]
        public void MissingEnd()
        {
            Assert.AreEqual(false, "{".FirstAndLastBracketsMatch('{', '}'));
        }

        [TestMethod]
        public void MissingEndLonger()
        {
            Assert.AreEqual(false, "{{}".FirstAndLastBracketsMatch('{', '}'));
        }

        [TestMethod]
        public void MisMatch()
        {
            Assert.AreEqual(false, "{}{}".FirstAndLastBracketsMatch('{', '}'));
        }

        [TestMethod]
        public void WithInner()
        {
            Assert.AreEqual(true, "{{}}".FirstAndLastBracketsMatch('{', '}'));
        }

    }
}
