using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Bank;
using Open.Domain.Bank;

namespace Open.Infra.Bank
{
    public class TransactionRepository : Repository<Transaction, TransactionData>, ITransactionRepository {
        public TransactionRepository(ApplicationDbContext c) : base(c?.Transactions, c) { }

        protected internal override Transaction createObject(TransactionData r) { return new Transaction(r); }

        protected internal override PaginatedList<Transaction> createList(List<TransactionData> l,
            RepositoryPage p) {
            return new TransactionList(l, p);
        }

        protected internal override async Task<TransactionData> getObject(string id) {
            return await dbSet.AsNoTracking()
                .SingleOrDefaultAsync(x => x.ID == id);
        }
    }
}