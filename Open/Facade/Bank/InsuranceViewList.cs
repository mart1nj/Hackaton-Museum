using Open.Core;
using Open.Domain.Bank;
namespace Open.Facade.Bank
{
    public class InsuranceViewsList : PaginatedList<InsuranceView>
    {
        public InsuranceViewsList(IPaginatedList<Insurance> list)
        {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list) { Add(InsuranceViewFactory.Create(e)); }
        }
    }
}
