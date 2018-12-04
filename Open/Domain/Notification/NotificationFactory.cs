using System;
using Open.Core;
using Open.Data.Notification;
namespace Open.Domain.Notification {
    public static class NotificationFactory {
        public static INotification Create(NotificationData data) {
            switch (data) {
                case WelcomeNotificationData welcome:
                    return create(welcome);
                case NewRequestTransactionNotificationData request:
                    return create(request);
                case NewTransactionNotificationData newTransaction:
                    return create(newTransaction);
                /* case AccountExpireNotificationData accountExpire:
                     return create(accountExpire);*/
            }

            return create((WelcomeNotificationData) null);
        }
        private static WelcomeNotification create(WelcomeNotificationData data) {
            return new WelcomeNotification(data);
        }
        public static WelcomeNotification CreateWelcomeNotification(string id, string senderId,
            string receiverId, bool? isSeen = false,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var r = new WelcomeNotificationData {
                ID = id,
                ReceiverId = receiverId,
                SenderId = senderId,
                IsSeen = isSeen,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new WelcomeNotification(r);
        }
        private static NewTransactionNotification create(NewTransactionNotificationData data) {
            return new NewTransactionNotification(data);
        }
        public static NewTransactionNotification CreateNewTransactionNotification(string id,
            string senderId, string receiverId, decimal? amount, bool? isSeen = false,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var r = new NewTransactionNotificationData {
                ID = id,
                ReceiverId = receiverId,
                SenderId = senderId,
                Amount = amount,
                IsSeen = isSeen,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new NewTransactionNotification(r);
        }
        private static NewRequestTransactionNotification create(
            NewRequestTransactionNotificationData data) {
            return new NewRequestTransactionNotification(data);
        }
        public static NewRequestTransactionNotification CreateNewRequestTransactionNotification(
            string id, string senderId, string receiverId, decimal? amount, TransactionStatus status = TransactionStatus.Pending,
            bool? isSeen = false,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var r = new NewRequestTransactionNotificationData {
                ID = id,
                ReceiverId = receiverId,
                SenderId = senderId,
                Amount = amount,
                Status = status,
                IsSeen = isSeen,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new NewRequestTransactionNotification(r);
        }
    }
}





