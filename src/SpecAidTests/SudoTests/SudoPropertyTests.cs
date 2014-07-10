using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecAid;

namespace SpecAidTests.SudoTests
{
    class TheClass
    {
        public string That { get; private set; }
    }

    [TestClass]
    public class SudoPropertyTests
    {
        [TestMethod]
        public void CanSetPrivate()
        {
            var someObject = new TheClass();

            Sudo.Prop(someObject, x => x.That).Value = "Name";

            Assert.AreEqual("Name", someObject.That);
        }
    }
}
