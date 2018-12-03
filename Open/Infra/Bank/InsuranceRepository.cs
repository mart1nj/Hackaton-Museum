using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Bank;
using Open.Domain.Bank;
namespace Open.Infra.Bank
{
    public class InsuranceRepository : Repository<Insurance, InsuranceData>, IInsuranceRepository
    {
        public InsuranceRepository(ApplicationDbContext c) : base(c?.Insurances, c) { }

        protected internal override Insurance createObject(InsuranceData r) { return new Insurance(r); }

        protected internal override PaginatedList<Insurance> createList(List<InsuranceData> l,
            RepositoryPage p)
        {
            return new InsuranceList(l, p);
        }

        protected internal override async Task<InsuranceData> getObject(string id)
        {
            return await dbSet.AsNoTracking()
                .SingleOrDefaultAsync(x => x.ID == id);
        }

        public async Task<PaginatedList<Insurance>> LoadInsurancesForUser(List<string> ids)
        {
            var insurances = getSorted().Where(s => s.Contains(SearchString) && ids.Contains(s.AccountId)).AsNoTracking();
            var count = await insurances.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await insurances.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }
    }
}
