using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid.Extentions;

namespace SpecAidTests.ExtentionTests
{
    [TestClass]
    public class StringTrimAlphaOmegaExtentionTests
    {
        [TestMethod]
        public void RemoveFirstAndLast()
        {
            Assert.AreEqual("2","123".TrimAlphaOmega());
        }

        [TestMethod]
        public void RemoveFirstAndLastLonger()
        {
            Assert.AreEqual("23", "1234".TrimAlphaOmega());
        }

        [TestMethod]
        public void RemoveFirstAndLastShorter()
        {
            Assert.AreEqual("", "12".TrimAlphaOmega());
        }

        [TestMethod]
        public void RemoveFirstAndLastTooShort()
        {
            Assert.AreEqual("1", "1".TrimAlphaOmega());
        }

        [TestMethod]
        public void RemoveFirstAndLastEmpty()
        {
            Assert.AreEqual("", "".TrimAlphaOmega());
        }

        [TestMethod]
        public void RemoveFirstAndLastNull()
        {
            Assert.IsNull(((string)null).TrimAlphaOmega());
        }
    }
}
