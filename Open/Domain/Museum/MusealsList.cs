using System.Collections.Generic;
using Open.Core;
using Open.Data.Museum;
namespace Open.Domain.Museum
{
    public class MusealsList : PaginatedList<Museal>
    {
        public MusealsList(IEnumerable<MusealData> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new Museal(dbRecord));
            }
        }
    }
}




