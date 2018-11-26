using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Bank;
using Open.Domain.Bank;

namespace Open.Infra.Bank
{
    public class TransactionRepository : Repository<Transaction, TransactionData>, ITransactionRepository {
        public TransactionRepository(ApplicationDbContext c) : base(c?.Transactions, c) {
            PageSize = 100;
        }

        protected internal override Transaction createObject(TransactionData r) { return new Transaction(r); }

        protected internal override PaginatedList<Transaction> createList(List<TransactionData> l,
            RepositoryPage p) {
            return new TransactionList(l, p);
        }

        protected internal override async Task<TransactionData> getObject(string id) {
            return await dbSet.AsNoTracking()
                .SingleOrDefaultAsync(x => x.ID == id);
        }

        public async Task<PaginatedList<Transaction>> LoadTransactionsForAccount(string id)
        {
            var objects = getSorted().Where(s => s.Contains(SearchString) && (s.SenderAccountId == id || s.ReceiverAccountId == id)).AsNoTracking();
            var count = await objects.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await objects.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }
    }
}