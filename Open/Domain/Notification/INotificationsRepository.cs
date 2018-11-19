using System.Collections.Generic;
using System.Threading.Tasks;
using Open.Core;
using Open.Data.Notification;
namespace Open.Domain.Notification
{
    public interface INotificationsRepository : IRepository<INotification, NotificationData> {
        Task<PaginatedList<INotification>> LoadNotificationsForAllUsers(List<string> ids);
    }
}



