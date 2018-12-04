using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Bank;
using Open.Domain.Bank;

namespace Open.Infra.Bank
{
    public class RequestTransactionRepository : Repository<RequestTransaction, RequestTransactionData>, IRequestTransactionRepository
    {
        public RequestTransactionRepository(ApplicationDbContext c) : base(c?.RequestTransactions, c)
        {
            PageSize = 100;
        }

        protected internal override RequestTransaction createObject(RequestTransactionData r) { return new RequestTransaction(r); }

        protected internal override PaginatedList<RequestTransaction> createList(List<RequestTransactionData> l,
            RepositoryPage p)
        {
            return new RequestTransactionList(l, p);
        }

        protected internal override async Task<RequestTransactionData> getObject(string id)
        {
            return await dbSet.AsNoTracking()
                .SingleOrDefaultAsync(x => x.ID == id);
        }
        public async Task<PaginatedList<RequestTransaction>> LoadReceivedRequestsForAccount(string id) {
            var objects = getSorted().Where(s => s.Contains(SearchString) && s.SenderAccountId == id).AsNoTracking();
            return await createPaginatedList(objects);
        }
        public async Task<PaginatedList<RequestTransaction>> LoadSentRequestsForAccount(string id)
        {
            var objects = getSorted().Where(s => s.Contains(SearchString) && s.ReceiverAccountId == id).AsNoTracking();
            return await createPaginatedList(objects);
        }
        private async Task<PaginatedList<RequestTransaction>> createPaginatedList(IQueryable<RequestTransactionData> objects) {
            var count = await objects.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await objects.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }
    }
}