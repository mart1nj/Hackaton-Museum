using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Bank;
using Open.Domain.Bank;
namespace Open.Tests.Domain.Bank
{
    [TestClass]
    public class ClientTests : EntityBaseTests<Client, ClientData>
    {
        protected override Client getRandomObject()
        {
            createdWithNullArg = new Client(null);
            dbRecordType = typeof(ClientData);
            return GetRandom.Object<Client>();
        }
        [TestMethod]
        public void GeographicAddressTest()
        {
            Assert.AreEqual(obj.GeographicAddress.Data, obj.Data.GeographicAddress);
        }
        [TestMethod]
        public void EmailAddressTest()
        {
            Assert.AreEqual(obj.EmailAddress.Data, obj.Data.EmailAddress);
        }
        [TestMethod]
        public void WhenCreatedWithNullArgumentsTest()
        {
            obj = new Client(null);
            Assert.IsNull(obj.Data.GeographicAddress);
            Assert.IsNotNull(obj.GeographicAddress.Data);
            Assert.IsNull(obj.Data.EmailAddress);
            Assert.IsNotNull(obj.EmailAddress.Data);
        }
    }
}
