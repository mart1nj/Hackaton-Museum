using System.Collections.Generic;
using Open.Core;
using Open.Data.Bank;

namespace Open.Domain.Bank
{
    public class RequestTransactionList : PaginatedList<RequestTransaction>
    {
        public RequestTransactionList(IEnumerable<RequestTransactionData> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add((RequestTransaction)TransactionFactory.Create(dbRecord));
            }
        }
    }
}