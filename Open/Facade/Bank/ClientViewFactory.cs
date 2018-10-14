using System;
using Open.Domain.Bank;
using Open.Facade.Party;

namespace Open.Facade.Bank {
    public static class ClientViewFactory {
        public static ClientView Create(Client o) {
            var v = new ClientView {
                FirstName = o?.Data.FirstName,
                LastName = o?.Data.LastName,
                ID = o?.Data.ID,
            };
            if (o is null) return v;
            v.ValidFrom = setNullIfExtremum(o.Data.ValidFrom);
            v.ValidTo = setNullIfExtremum(o.Data.ValidTo);
            //TODO geoaddress and Emailaddress data to view
          //  v.GeographicAddress = o.Data.GeographicAddress; //või geoAddID?
          //  v.EmailAddress = o.Data.EmailAddress; //või emailAddID?
            return v;
        }
        private static DateTime? setNullIfExtremum(DateTime d) {
            if (d.Date >= DateTime.MaxValue.Date) return null;
            if (d.Date <= DateTime.MinValue.AddDays(1).Date) return null;
            return d;
        }
    }
}





