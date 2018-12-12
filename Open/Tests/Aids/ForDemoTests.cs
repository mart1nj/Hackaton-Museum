using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
namespace Open.Tests.Aids
{
    [TestClass]
    public class ForDemoTests: BaseTests
    {
        [TestInitialize]
        public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(ForDemo);
        }
        [TestMethod] public void AddTest() {
            Assert.AreEqual(4, ForDemo.Add(2,2));
        }

    }
}
