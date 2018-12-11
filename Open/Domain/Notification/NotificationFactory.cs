using System;
using Open.Core;
using Open.Data.Notification;
namespace Open.Domain.Notification {
    public static class NotificationFactory {
        public static INotification Create(NotificationData data) {
            switch (data) {
                case WelcomeNotificationData welcome:
                    return create(welcome);
                case RequestStatusNotificationData reqStatus:
                    return create(reqStatus);
                case NewRequestTransactionNotificationData request:
                    return create(request);
                case NewTransactionNotificationData newTransaction:
                    return create(newTransaction);
                case NewInsuranceNotificationData newInsurance:
                    return create(newInsurance);
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
        private static RequestStatusNotification create(RequestStatusNotificationData data)
        {
            return new RequestStatusNotification(data);
        }
        public static RequestStatusNotification CreateRequestStatusNotification(string id, string senderId,
            string receiverId, decimal? amount, TransactionStatus status = TransactionStatus.Pending, bool? isSeen = false,
            DateTime? validFrom = null, DateTime? validTo = null)
        {
            var r = new RequestStatusNotificationData
            {
                ID = id,
                ReceiverId = receiverId,
                SenderId = senderId,
                Amount = amount,
                Status = status,
                IsSeen = isSeen,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new RequestStatusNotification(r);
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
            string id, string senderId, string receiverId, decimal? amount,
            bool? isSeen = false,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var r = new NewRequestTransactionNotificationData {
                ID = id,
                ReceiverId = receiverId,
                SenderId = senderId,
                Amount = amount,
                IsSeen = isSeen,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new NewRequestTransactionNotification(r);
        }
        
        private static NewInsuranceNotification create(NewInsuranceNotificationData data) {
            return new NewInsuranceNotification(data);
        }
        public static NewInsuranceNotification CreateNewInsuranceNotification(string id, string senderId,string accountId,
            string type, bool? isSeen = false,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var r = new NewInsuranceNotificationData {
                ID = id,
                SenderId = senderId,
                ReceiverId = accountId,
                InsuranceType = type,
                IsSeen = isSeen,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new NewInsuranceNotification(r);
        }
    }
}





