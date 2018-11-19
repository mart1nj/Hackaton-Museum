using Open.Core;
using Open.Domain.Notification;
using Open.Facade.Bank;
namespace Open.Facade.Notification
{
    public class NotificationViewsList : PaginatedList<NotificationView> {
        public NotificationViewsList(IPaginatedList<INotification> list)
        {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list) { Add(NotificationViewFactory.Create(e)); }
        }
    }
}
