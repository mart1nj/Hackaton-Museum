using System.Collections.Generic;
using Open.Core;
using Open.Data.Notification;
namespace Open.Domain.Notification
{
    public class NotificationsList : PaginatedList<INotification>
    {
        public NotificationsList(IEnumerable<NotificationData> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(NotificationFactory.Create(dbRecord));
            }
        }
    }
}




