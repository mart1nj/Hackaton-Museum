using Open.Core;
using Open.Domain.Bank;

namespace Open.Facade.Bank
{
    public class TransactionViewsList : PaginatedList<TransactionView> {
        public TransactionViewsList(IPaginatedList<Transaction> list) {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list)
            {
                Add(TransactionViewFactory.Create(e));
            }
        }
    }
}