using System.Collections.Generic;
using Open.Core;
using Open.Data.Bank;

namespace Open.Domain.Bank
{
    public class TransactionList : PaginatedList<Transaction>
    {
        public TransactionList(IEnumerable<TransactionData> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add((Transaction) TransactionFactory.Create(dbRecord));
            }
        }
    }
}