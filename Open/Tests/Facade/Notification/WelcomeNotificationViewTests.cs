using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Notification;
namespace Open.Tests.Facade.Notification
{
    [TestClass]
    public class WelcomeNotificationViewTests : ObjectTests<WelcomeNotificationView>
    {
        protected override WelcomeNotificationView getRandomObject()
        {
            return GetRandom.Object<WelcomeNotificationView>();
        }
        [TestMethod]
        public void IsNotificationViewTest()
        {
            Assert.AreEqual(obj.GetType().BaseType, typeof(NotificationView));
        }
        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual(obj.Message, obj.ToString());
        }

    }
}


