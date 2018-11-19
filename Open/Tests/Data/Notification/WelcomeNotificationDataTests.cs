using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Notification;
namespace Open.Tests.Data.Notification
{
    [TestClass]
    public class WelcomeNotificationDataTests : ObjectTests<WelcomeNotificationData>
    {
        class testClass : WelcomeNotificationData { }
        protected override WelcomeNotificationData getRandomObject()
        {
            return GetRandom.Object<testClass>();
        }
        [TestMethod]
        public void IsInstanceOfNotificationData()
        {
            Assert.AreEqual(typeof(NotificationData), typeof(WelcomeNotificationData).BaseType);
        }
        [TestMethod]
        public void MessageTest() {

            canReadWrite(() => obj.Message, x => obj.Message = x);
            obj.Message = null;
            Assert.AreEqual("Welcome to SonicBank! Thank you for opening an account!", obj.Message);
        }
    }
}