using System.Collections.Generic;
using Open.Core;
using Open.Data.Bank;
namespace Open.Domain.Bank
{  
    public class InsuranceList : PaginatedList<Insurance>
    {
        public InsuranceList(IEnumerable<InsuranceData> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new Insurance(dbRecord));
            }
        }
    }
}
