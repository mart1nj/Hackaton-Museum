using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Bank;
using Open.Domain.Bank;
namespace Open.Tests.Domain.Bank
{
    [TestClass]
    public class InsuranceTests : EntityBaseTests<Insurance, InsuranceData>
    {
        protected override Insurance getRandomObject()
        {
            createdWithNullArg = new Insurance(null);
            dbRecordType = typeof(InsuranceData);
            return GetRandom.Object<Insurance>();
        }
        [TestMethod]
        public void AccountTest()
        {
            Assert.AreEqual(obj.Account.Data, obj.Data.Account);
        }
        
        [TestMethod]
        public void WhenCreatedWithNullArgumentsTest()
        {
            obj = new Insurance(null);
            Assert.IsNull(obj.Data.Account);
            Assert.IsNotNull(obj.Account.Data);
        }
    }
}

