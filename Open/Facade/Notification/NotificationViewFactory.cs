using System;
using Open.Core;
using Open.Domain.Notification;
namespace Open.Facade.Notification {
    public static class NotificationViewFactory {
        public static NotificationView Create(INotification o) {
            switch (o) {
                case RequestStatusNotification reqStatus: return create(reqStatus);
                case NewRequestTransactionNotification newRequest: return create(newRequest);
                case NewTransactionNotification newTransaction: return create(newTransaction);
                case NewInsuranceNotification newInsurance : return create(newInsurance);
                default: return create(o as WelcomeNotification);
            }
        }
        private static WelcomeNotificationView create(WelcomeNotification o) {
            var v = new WelcomeNotificationView();
            setCommonValues(v, o?.Data?.ID, o?.Data?.Message, o?.Data?.SenderId, o?.Data?.ReceiverId,
                o?.Data?.IsSeen, o?.Data?.ValidFrom, o?.Data?.ValidTo);
            return v;
        }
        private static NewTransactionNotificationView create(NewTransactionNotification o) {
            var v = new NewTransactionNotificationView {Amount = o?.Data.Amount};
            setCommonValues(v, o?.Data?.ID, o?.Data?.Message, o?.Data?.SenderId, o?.Data?.ReceiverId,
                o?.Data?.IsSeen, o?.Data?.ValidFrom, o?.Data?.ValidTo);
            return v;
        }
        
        private static NewRequestTransactionNotificationView create(NewRequestTransactionNotification o)
        {
            var v = new NewRequestTransactionNotificationView { Amount = o?.Data.Amount };
            setCommonValues(v, o?.Data?.ID, o?.Data?.Message, o?.Data?.SenderId, o?.Data?.ReceiverId,
                o?.Data?.IsSeen, o?.Data?.ValidFrom, o?.Data?.ValidTo);
            return v;
        }
        private static RequestStatusNotificationView create(RequestStatusNotification o)
        {
            var v = new RequestStatusNotificationView { Amount = o?.Data.Amount, Status = o?.Data.Status ?? TransactionStatus.Pending };
            setCommonValues(v, o?.Data?.ID, o?.Data?.Message, o?.Data?.SenderId, o?.Data?.ReceiverId,
                o?.Data?.IsSeen, o?.Data?.ValidFrom, o?.Data?.ValidTo);
            return v;
        }

        private static NewInsuranceNotificationView create(NewInsuranceNotification o)
        {
            var v = new NewInsuranceNotificationView { InsuranceType = o?.Data.InsuranceType};
            setCommonValues(v, o?.Data?.ID, o?.Data?.Message, o?.Data?.SenderId, o?.Data?.ReceiverId,
                o?.Data?.IsSeen, o?.Data?.ValidFrom, o?.Data?.ValidTo);
            return v;
        }
      /*  public static WelcomeNotification Create(WelcomeNotificationView v) {
            var d = new WelcomeNotificationData {
                ID = v.ID,
                Message = v.Message,
                SenderId = v.SenderAccountId,
                ReceiverId = v.ReceiverAccountId,
                IsSeen = v.IsSeen,
                ValidTo = v.ValidTo ?? DateTime.MaxValue,
                ValidFrom = v.ValidFrom ?? DateTime.MinValue
            };
            return new WelcomeNotification(d);
        }
        public static NewTransactionNotification Create(NewTransactionNotificationView v) {
            var d = new NewTransactionNotificationData {
                ID = v.ID,
                Message = v.Message,
                SenderId = v.SenderAccountId,
                ReceiverId = v.ReceiverAccountId,
                IsSeen = v.IsSeen,
                Amount = v.Amount,
                ValidTo = v.ValidTo ?? DateTime.MaxValue,
                ValidFrom = v.ValidFrom ?? DateTime.MinValue
            };
            return new NewTransactionNotification(d);
        }
        public static NewRequestTransactionNotification Create(NewRequestTransactionNotificationView v)
        {
            var d = new NewRequestTransactionNotificationData
            {
                ID = v.ID,
                Message = v.Message,
                SenderId = v.SenderAccountId,
                ReceiverId = v.ReceiverAccountId,
                IsSeen = v.IsSeen,
                Amount = v.Amount,
                Status = v.Status,
                ValidTo = v.ValidTo ?? DateTime.MaxValue,
                ValidFrom = v.ValidFrom ?? DateTime.MinValue
            };
            return new NewRequestTransactionNotification(d);
        }*/
        private static void setCommonValues(NotificationView model, string id, string message,
            string senderId, string receiverId, bool? isSeen, DateTime? validFrom,
            DateTime? validTo) {
            model.ID = id;
            model.Message = message;
            model.SenderAccountId = senderId;
            model.ReceiverAccountId = receiverId;
            model.IsSeen = isSeen;
            model.ValidFrom = setNullIfExtremum(validFrom ?? DateTime.MinValue);
            model.ValidTo = setNullIfExtremum(validTo ?? DateTime.MaxValue);
        }
        private static DateTime? setNullIfExtremum(DateTime d) {
            if (d.Date >= DateTime.MaxValue.Date) return null;
            if (d.Date <= DateTime.MinValue.AddDays(1).Date) return null;
            return d;
        }
    }
}
