using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Notification;
using Open.Domain.Notification;
namespace Open.Infra.Notification
{
    public class NotificationsRepository : INotificationsRepository
    {
        private readonly DbSet<NotificationData> dbSet;
        private readonly DbContext db;
        public NotificationsRepository(ApplicationDbContext c)
        {
            db = c;
            dbSet = c?.Notifications;
            PageSize = 100;
        }
        public string SearchString { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public SortOrder SortOrder { get; set; }
        public Func<NotificationData, object> SortFunction { get; set; }
        public async Task<PaginatedList<INotification>> GetObjectsList()
        {
            var notifications = getSorted().Where(s => s.Contains(SearchString)).AsNoTracking();
            var count = await notifications.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await notifications.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }
        protected internal PaginatedList<INotification> createList(
            List<NotificationData> l, RepositoryPage p)
        {
            return new NotificationsList(l, p);
        }
        private IQueryable<NotificationData> getSet()
        {
            return from s in dbSet select s;
        }
        private IQueryable<NotificationData> getSorted()
        {
            if (SortFunction is null) return getSet();
            return SortOrder == SortOrder.Descending
                ? getSet().OrderByDescending(x => SortFunction(x))
                : getSet().OrderBy(x => SortFunction(x));
        }
        protected internal async Task<NotificationData> getObject(string id)
        {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == id);
        }
        public async Task<INotification> GetObject(string id)
        {
            var r = await getObject(id);
            return NotificationFactory.Create(r);
        }
        public async Task AddObject(INotification o)
        {
            if (o is WelcomeNotification welcome) dbSet.Add(welcome.Data);
            if (o is RequestStatusNotification reqStatus) dbSet.Add(reqStatus.Data);
            if (o is NewRequestTransactionNotification newRequest) dbSet.Add(newRequest.Data);
            if (o is NewTransactionNotification newTransaction) dbSet.Add(newTransaction.Data);
            if (o is NewInsuranceNotification newInsurance) dbSet.Add(newInsurance.Data);
           // if (o is TelecomAddress tel) dbSet.Add(tel.Data);*/
            await db.SaveChangesAsync();
        }
        public async Task UpdateObject(INotification o)
        {
            if (o is WelcomeNotification welcome) dbSet.Update(welcome.Data);
            if (o is RequestStatusNotification reqStatus) dbSet.Update(reqStatus.Data);
            if (o is NewRequestTransactionNotification newRequest) dbSet.Update(newRequest.Data);
            if (o is NewTransactionNotification newTransaction) dbSet.Update(newTransaction.Data);
            if (o is NewInsuranceNotification newInsurance) dbSet.Update(newInsurance.Data);
           // if (o is TelecomAddress tel) dbSet.Update(tel.Data);
            await db.SaveChangesAsync();
        }
        public async Task DeleteObject(INotification o)
        {
            if (o is WelcomeNotification welcome) dbSet.Remove(welcome.Data);
            if (o is RequestStatusNotification reqStatus) dbSet.Remove(reqStatus.Data);
            if (o is NewRequestTransactionNotification newRequest) dbSet.Remove(newRequest.Data);
            if (o is NewTransactionNotification newTransaction) dbSet.Remove(newTransaction.Data);
            if (o is NewInsuranceNotification newInsurance) dbSet.Remove(newInsurance.Data);
      //      if (o is TelecomAddress tel) dbSet.Remove(tel.Data);
            await db.SaveChangesAsync();
        }
        public bool IsInitialized()
        {
            db.Database.EnsureCreated();
            return dbSet.Any();
        }
        public async Task<PaginatedList<INotification>> LoadNotificationsForAllUsers(List<string> ids)
        {
            var notifications = getSorted().Where(s => s.Contains(SearchString) && ids.Contains(s.ReceiverId)).AsNoTracking();
            var count = await notifications.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await notifications.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }
    }
}