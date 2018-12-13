using Open.Core;
using Open.Domain.Museum;
namespace Open.Facade.Museum
{
    public class MusealViewsList : PaginatedList<MusealView>
    {
        public MusealViewsList(IPaginatedList<Museal> list)
        {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var item in list)
            {
                Add(MusealViewFactory.CreateMuseal(item));
            }
        }
    }
}



