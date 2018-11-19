using System;
using Open.Data.Notification;
namespace Open.Domain.Notification
{
    public static class NotificationFactory
    {
        public static INotification Create(NotificationData data)
        {
              switch (data)
             {
                 case WelcomeNotificationData welcome:
                     return create(welcome);
               /*  case NewTransactionRequestNotificationData newTransactionRequest:
                     return create(newTransactionRequest);
                 case AccountExpireNotificationData accountExpire:
                     return create(accountExpire);
                 case RequestStatusNotificationData requestStatus:
                     return create(requestStatus);*/
             }

            return null;
            //return create(data as WelcomeNotificationData);
        }
        private static WelcomeNotification create(WelcomeNotificationData data)
        {
            return new WelcomeNotification(data);
        }
        public static WelcomeNotification CreateWelcomeNotification(string id, string senderId, string receiverId, bool? isSeen = false,
            DateTime? validFrom = null, DateTime? validTo = null)
        {
            var r = new WelcomeNotificationData
            {
                ID = id,
                ReceiverId = receiverId,
                SenderId = senderId,
                IsSeen = isSeen,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new WelcomeNotification(r);
        }
    }
}





