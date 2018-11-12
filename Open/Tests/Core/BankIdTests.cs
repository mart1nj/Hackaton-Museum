using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Core;

namespace Open.Tests.Core {
    
    [TestClass]
    public class BankIdTests : BaseTests {

        [TestInitialize] public void InitializeTest() {
            base.TestInitialize();
            type = typeof(BankId);
        }

        [TestMethod] public void NewBankIdTest() {
            Assert.Inconclusive();
        }
        
        [TestMethod] public void IsNotNullTest() {
            Assert.IsNotNull(BankId.NewBankId());
        }
        
        [TestMethod] public void IsIdTypeOfStringTest() {
            Assert.IsTrue(BankId.NewBankId().GetType() == typeof(string));
        }
    }
}
