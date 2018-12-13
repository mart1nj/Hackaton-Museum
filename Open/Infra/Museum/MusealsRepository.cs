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
    public class MusealsRepository : IMusealsRepository
    {
        private readonly DbSet<MusealData> dbSet;
        private readonly DbContext db;
        public MusealsRepository(ApplicationDbContext c)
        {
            db = c;
            dbSet = c?.Museals;
        }
        public string SearchString { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public SortOrder SortOrder { get; set; }
        public Func<MusealData, object> SortFunction { get; set; }
        public async Task<PaginatedList<Museal>> GetObjectsList()
        {
            var countries = getSorted().Where(s => s.Contains(SearchString)).AsNoTracking();
            var count = await countries.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await countries.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }
        protected internal PaginatedList<Museal> createList(
            List<MusealData> l, RepositoryPage p)
        {
            return new MusealsList(l, p);
        }
        private IQueryable<MusealData> getSet()
        {
            return from s in dbSet select s;
        }
        private IQueryable<MusealData> getSorted()
        {
            if (SortFunction is null) return getSet();
            return SortOrder == SortOrder.Descending
                ? getSet().OrderByDescending(x => SortFunction(x))
                : getSet().OrderBy(x => SortFunction(x));
        }
        protected internal async Task<MusealData> getObject(string id)
        {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == id);
        }
        public async Task<Museal> GetObject(string id)
        {
            var r = await getObject(id);
            return new Museal(r);
        }
        public async Task AddObject(Museal o)
        {
            dbSet.Add(o.Data);
            await db.SaveChangesAsync();
        }
        public async Task UpdateObject(Museal o)
        {
            dbSet.Update(o.Data);
            await db.SaveChangesAsync();
        }
        public async Task DeleteObject(Museal o)
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


