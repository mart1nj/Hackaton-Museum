using Open.Core;
using Open.Domain.Bank;

namespace Open.Facade.Bank
{
    public class RequestTransactionViewsList : PaginatedList<RequestTransactionView>
    {
        public RequestTransactionViewsList(IPaginatedList<RequestTransaction> list)
        {
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