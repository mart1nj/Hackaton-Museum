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
    public class InventoryMusealsRepository : IInventoryMusealsRepository
    {
        private readonly DbSet<InventoryMusealData> dbSet;
        private readonly DbContext db;
        public InventoryMusealsRepository(ApplicationDbContext c)
        {
            db = c;
            dbSet = c?.InventoryMuseals;
        }
        public string SearchString { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public SortOrder SortOrder { get; set; }
        public Func<InventoryMusealData, object> SortFunction { get; set; }
        public async Task<PaginatedList<InventoryMuseal>> GetObjectsList()
        {
            var countries = getSorted().Where(s => s.Contains(SearchString)).AsNoTracking();
            var count = await countries.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await countries.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }
        protected internal PaginatedList<InventoryMuseal> createList(
            List<InventoryMusealData> l, RepositoryPage p)
        {
            return new InventoryMusealsList(l, p);
        }
        private IQueryable<InventoryMusealData> getSet()
        {
            return from s in dbSet select s;
        }
        private IQueryable<InventoryMusealData> getSorted()
        {
            if (SortFunction is null) return getSet();
            return SortOrder == SortOrder.Descending
                ? getSet().OrderByDescending(x => SortFunction(x))
                : getSet().OrderBy(x => SortFunction(x));
        }
        protected internal async Task<InventoryMusealData> getObject(string id)
        {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == id);
        }
        public async Task<InventoryMuseal> GetObject(string id)
        {
            var r = await getObject(id);
            return new InventoryMuseal(r);
        }
        public async Task AddObject(InventoryMuseal o)
        {
            dbSet.Add(o.Data);
            await db.SaveChangesAsync();
        }
        public async Task UpdateObject(InventoryMuseal o)
        {
            dbSet.Update(o.Data);
            await db.SaveChangesAsync();
        }
        public async Task DeleteObject(InventoryMuseal o)
        {
            dbSet.Remove(o.Data);
            await db.SaveChangesAsync();
        }
        public bool IsInitialized()
        {
            db.Database.EnsureCreated();
            return dbSet.Any();
        }
        public async Task<IPaginatedList<InventoryMuseal>> GetMusealInventoriesList(string musealID)
        {
            var musealInventories = getSorted().Where(s => s.Contains(SearchString) && s.MusealID == musealID).AsNoTracking();
            var count = await musealInventories.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await musealInventories.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }
        public async Task<IPaginatedList<InventoryMuseal>> GetInventoryMusealsList(string inventoryID)
        {
            var inventoryMuseals = getSorted().Where(s => s.Contains(SearchString) && s.InventoryID == inventoryID).AsNoTracking();
            var count = await inventoryMuseals.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await inventoryMuseals.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }
    }
}


