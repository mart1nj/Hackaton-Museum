using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Museum;
using Open.Domain.Museum;
namespace Open.Infra.Museum
{
    public class InventoriesRepository : IInventoriesRepository
    {
        private readonly DbSet<InventoryData> dbSet;
        private readonly DbContext db;
        public InventoriesRepository(ApplicationDbContext c)
        {
            db = c;
            dbSet = c?.Inventories;
        }
        public string SearchString { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public SortOrder SortOrder { get; set; }
        public Func<InventoryData, object> SortFunction { get; set; }
        public async Task<PaginatedList<Inventory>> GetObjectsList()
        {
            var countries = getSorted().Where(s => s.Contains(SearchString)).AsNoTracking();
            var count = await countries.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await countries.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }
        protected internal PaginatedList<Inventory> createList(
            List<InventoryData> l, RepositoryPage p)
        {
            return new InventoriesList(l, p);
        }
        private IQueryable<InventoryData> getSet()
        {
            return from s in dbSet select s;
        }
        private IQueryable<InventoryData> getSorted()
        {
            if (SortFunction is null) return getSet();
            return SortOrder == SortOrder.Descending
                ? getSet().OrderByDescending(x => SortFunction(x))
                : getSet().OrderBy(x => SortFunction(x));
        }
        protected internal async Task<InventoryData> getObject(string id)
        {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == id);
        }
        public async Task<Inventory> GetObject(string id)
        {
            var r = await getObject(id);
            return new Inventory(r);
        }
        public async Task AddObject(Inventory o)
        {
            dbSet.Add(o.Data);
            await db.SaveChangesAsync();
        }
        public async Task UpdateObject(Inventory o)
        {
            dbSet.Update(o.Data);
            await db.SaveChangesAsync();
        }
        public async Task DeleteObject(Inventory o)
        {
            dbSet.Remove(o.Data);
            await db.SaveChangesAsync();
        }
        public bool IsInitialized()
        {
            db.Database.EnsureCreated();
            return dbSet.Any();
        }
    }
}


