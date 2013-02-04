using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecAidTests.SpecflowWiredUp
{
    [Binding]
    [Scope(Tag = "SpecflowWiredUp")]
    public class SpecflowWiredUpSteps
    {
        [Then(@"Assert True")]
        public void ThenAssertTrue()
        {
            Assert.AreEqual(true, true);
        }
    }
}
