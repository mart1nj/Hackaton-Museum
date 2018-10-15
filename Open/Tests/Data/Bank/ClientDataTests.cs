using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Bank;
namespace Open.Tests.Data.Bank
{
    [TestClass]
    public class ClientDataTests : ObjectTests<ClientData>
    {
        class testClass : ClientData { }
        protected override ClientData getRandomObject()
        {
            return GetRandom.Object<testClass>();
        }
        [TestMethod]
        public void IsNotAbstract()
        {
            Assert.IsFalse(typeof(ClientData).IsAbstract);
        }
        [TestMethod]
        public void IsInstanceOfUniqueDbRecord()
        {
            Assert.AreEqual(typeof(IdentifiedData), typeof(ClientData).BaseType);
        }
        [TestMethod]
        public void FirstNameTest()
        {
            canReadWrite(() => obj.FirstName, x => obj.FirstName = x);
        }
        [TestMethod]
        public void LastNameTest()
        {
            canReadWrite(() => obj.LastName, x => obj.LastName = x);
        }
        [TestMethod]
        public void GeographicAddressIDTest()
        {
            canReadWrite(() => obj.GeographicAddressID,
                x => obj.GeographicAddressID = x);
        }
        [TestMethod]
        public void EmailAddressIDTest()
        {
            canReadWrite(() => obj.EmailAddressID,
                x => obj.EmailAddressID = x);
        }
        [TestMethod]
        public void GeographicAddressTest()
        {
            canReadWrite(() => obj.GeographicAddress, x => obj.GeographicAddress = x);
        }
        [TestMethod]
        public void EmailAddressTest()
        {
            canReadWrite(() => obj.EmailAddress, x => obj.EmailAddress = x);
        }
    }
}

