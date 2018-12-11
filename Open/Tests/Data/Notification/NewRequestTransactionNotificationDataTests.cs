using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Notification;
namespace Open.Tests.Data.Notification
{
    [TestClass]
    public class NewRequestTransactionNotificationDataTests : ObjectTests<NewRequestTransactionNotificationData>
    {
        class testClass : NewRequestTransactionNotificationData { }
        protected override NewRequestTransactionNotificationData getRandomObject()
        {
            return GetRandom.Object<testClass>();
        }
        [TestMethod]
        public void IsInstanceOfNewTransactionNotificationData()
        {
            Assert.AreEqual(typeof(NewTransactionNotificationData), typeof(NewRequestTransactionNotificationData).BaseType);
        }
        [TestMethod]
        public void MessageTest()
        {

            canReadWrite(() => obj.Message, x => obj.Message = x);
            obj.Message = null;
            Assert.AreEqual("has requested a transaction in the amount of", obj.Message);
        }
    }
}