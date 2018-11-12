using Open.Infra.Bank;
using Open.Infra.Notification;
using Open.Infra.Party;
using Open.Infra.Quantity;
namespace Open.Infra {
    public static class DbInitializer {
        public static void Initialize(ApplicationDbContext dbContext) {
            CountriesInitializer.Initialize(dbContext);
            ContactsInitializer.Initialize(dbContext);
            AspNetUserInitializer.Initialize(dbContext);
            TransactionsInitializer.Initialize(dbContext);
            NotificationsInitializer.Initialize(dbContext);
            CurrenciesInitializer.Initialize(dbContext);
            NationalCurrenciesInitializer.Initialize(dbContext);
           /*  EuroRateTypesInitializer.Initialize(dbContext);
             EuroRatesInitializer.Initialize(dbContext);*/

        }
    }
}


