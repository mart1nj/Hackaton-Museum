using System;
using Open.Data.Notification;
using Open.Domain.Notification;
namespace Open.Facade.Notification
{
    public static class NotificationViewFactory
    {

        public static NotificationView Create(INotification o)
        {
            switch (o)
            {
               // case WebPageAddress web: return create(web);
                default: return create(o as WelcomeNotification);
            }
        }

        private static WelcomeNotificationView create(WelcomeNotification o)
        {
            var v = new WelcomeNotificationView
            {
                Message = o.Data?.Message,
                SenderAccountId = o.Data?.SenderId,
                ReceiverAccountId = o.Data?.ReceiverId,
                IsSeen = o.Data?.IsSeen
            };
            setCommonValues(v, o.Data?.ID, o.Data?.ValidFrom, o.Data?.ValidTo);
            return v;
        }

        private static void setCommonValues(NotificationView model, string id, DateTime? validFrom,
            DateTime? validTo)
        {
            model.ID = id;
            model.ValidFrom = setNullIfExtremum(validFrom ?? DateTime.MinValue);
            model.ValidTo = setNullIfExtremum(validTo ?? DateTime.MaxValue);
        }
        private static DateTime? setNullIfExtremum(DateTime d)
        {
            if (d.Date >= DateTime.MaxValue.Date) return null;
            if (d.Date <= DateTime.MinValue.AddDays(1).Date) return null;
            return d;
        }
        public static WelcomeNotification Create(WelcomeNotificationView v)
        {
            var d = new WelcomeNotificationData
            {
                ID = v.ID,
                Message = v.Message,
                SenderId = v.SenderAccountId,
                ReceiverId = v.ReceiverAccountId,
                ValidTo = v.ValidTo ?? DateTime.MaxValue,
                ValidFrom = v.ValidFrom ?? DateTime.MinValue
            };
            return new WelcomeNotification(d);
        }
    }
}
