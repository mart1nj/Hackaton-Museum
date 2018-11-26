using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Notification;
namespace Open.Tests.Data.Notification
{
    [TestClass]
    public class NewTransactionNotificationDataTests : ObjectTests<NewTransactionNotificationData>
    {
        class testClass : NewTransactionNotificationData { }
        protected override NewTransactionNotificationData getRandomObject()
        {
            return GetRandom.Object<testClass>();
        }
        [TestMethod]
        public void IsInstanceOfNotificationData()
        {
            Assert.AreEqual(typeof(NotificationData), typeof(NewTransactionNotificationData).BaseType);
        }
        [TestMethod]
        public void MessageTest()
        {

            canReadWrite(() => obj.Message, x => obj.Message = x);
            obj.Message = null;
            Assert.AreEqual("has sent you a new transaction in the amount of", obj.Message);
        }
        [TestMethod]
        public void AmountTest()
        {
            canReadWrite(() => obj.Amount, x => obj.Amount = x);
        }
    }
}