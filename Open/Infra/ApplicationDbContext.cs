using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Open.Data.Bank;
using Open.Data.Notification;
using Open.Data.Party;
using Open.Data.Quantity;
namespace Open.Infra
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}
        public DbSet<CountryData> Countries { get; set; }
        public DbSet<CurrencyData> Currencies { get; set; }
        public DbSet<NationalCurrencyData> CountryCurrencies { get; set; }
        public DbSet<AddressData> Addresses { get; set; }
        public DbSet<TelecomDeviceRegistrationData> TelecomDeviceRegistrations { get; set; }

      //  public DbSet<RateData> Rates { get; set; }
      //  public DbSet<RateTypeData> RateTypes { get; set; }
      //  public DbSet<PaymentMethodData> PaymentMethods { get; set; }
      //  public DbSet<PaymentData> Payments { get; set; }

        public DbSet<AccountData> Accounts { get; set; }
        public DbSet<TransactionData> Transactions { get; set; }
        public DbSet<RequestTransactionData> RequestTransactions { get; set; }
        public DbSet<InsuranceData> Insurances { get; set; }
        public DbSet<NotificationData> Notifications { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<CurrencyData>().ToTable("Currency");
            builder.Entity<CountryData>().ToTable("Country");
         //   builder.Entity<RateTypeData>().ToTable("RateType");
            createAddressTable(builder);
            createTelecomAddressRegistrationTable(builder);
            createNationalCurrencyTable(builder);
         //   createPaymentMethodTable(builder);
         //   createRateTable(builder);
         //   createPaymentTable(builder);
            createAccountTable(builder);
            createTransactionTable(builder);
            createInsuranceTable(builder);
            createNotificationTable(builder);
            createForeignKey<ApplicationUser, GeographicAddressData>(builder, "AspNetUser", x => x.AddressID, x => x.Address);
        }
        
        private static void createInsuranceTable(ModelBuilder b){
            const string table = "Insurance";
            b.Entity<InsuranceData>().ToTable(table);
            createForeignKey<InsuranceData, AccountData>(b, table, x => x.AccountId, x => x.Account);
        }
        
        private static void createAccountTable(ModelBuilder b)
        {
            const string table = "Account";
            b.Entity<AccountData>().ToTable(table);
            createForeignKey<AccountData, ApplicationUser>(b, table, x => x.AspNetUserId, x => x.AspNetUser);
        }
        private static void createTransactionTable(ModelBuilder b)
        {
            const string table = "Transaction";
            b.Entity<TransactionData>().ToTable(table);
            createForeignKey<TransactionData, AccountData>(b, table, x => x.SenderAccountId, x => x.SenderAccount);
            createForeignKey<TransactionData, AccountData>(b, table, x => x.ReceiverAccountId, x => x.ReceiverAccount);
            const string reqTable = "RequestTransaction";
            b.Entity<RequestTransactionData>().ToTable(reqTable);
            createForeignKey<RequestTransactionData, AccountData>(b, reqTable, x => x.SenderAccountId, x => x.SenderAccount);
            createForeignKey<RequestTransactionData, AccountData>(b, reqTable, x => x.ReceiverAccountId, x => x.ReceiverAccount);
        }

        private static void createNotificationTable(ModelBuilder b)
        {
            const string table = "Notification";
            b.Entity<NotificationData>().ToTable(table);
            b.Entity<WelcomeNotificationData>().ToTable(table);
            b.Entity<RequestStatusNotificationData>().ToTable(table);
            b.Entity<NewRequestTransactionNotificationData>().ToTable(table);
            b.Entity<NewInsuranceNotificationData>().ToTable(table);
            b.Entity<NewTransactionNotificationData>().ToTable(table);
            createForeignKey<NotificationData, AccountData>(b, table, x => x.SenderId, x => x.Sender);
            createForeignKey<NotificationData, AccountData>(b, table, x => x.ReceiverId, x => x.Receiver);
        }
        /*   private static void createPaymentMethodTable(ModelBuilder b)
           {
               const string table = "PaymentMethod";
               b.Entity<CheckData>().ToTable(table);
               b.Entity<CreditCardData>().ToTable(table);
               b.Entity<DebitCardData>().ToTable(table);
               createForeignKey<PaymentMethodData, CurrencyData>(b, table, x => x.CurrencyID, x => x.Currency);
           }

           private static void createPaymentTable(ModelBuilder b)
           {
               const string table = "Payment";
               createForeignKey<PaymentData, CurrencyData>(b, table, x => x.CurrencyID, x => x.Currency);
               createForeignKey<PaymentData, PaymentMethodData>(b, table, x => x.PaymentMethodID, x => x.PaymentMethod);
           }

           private static void createRateTable(ModelBuilder b)
           {
               const string table = "Rate";
               createForeignKey<RateData, CurrencyData>(b, table, x => x.CurrencyID, x => x.Currency);
               createForeignKey<RateData, RateTypeData>(b, table, x => x.RateTypeID, x => x.RateType);
           }*/
           internal static void createAddressTable(ModelBuilder b)
           {
               const string table = "Address";
               b.Entity<AddressData>().ToTable(table);
               b.Entity<WebPageAddressData>().ToTable(table);
               b.Entity<EmailAddressData>().ToTable(table);
               b.Entity<TelecomAddressData>().ToTable(table);
               createForeignKey<GeographicAddressData, CountryData>(b, table, x => x.CountryID, x => x.Country);
           }
           internal static void createTelecomAddressRegistrationTable(ModelBuilder b)
           {
               const string table = "TelecomDeviceRegistration";
               createPrimaryKey<TelecomDeviceRegistrationData>(b, table, a => new { a.AddressID, a.DeviceID });
               createForeignKey<TelecomDeviceRegistrationData, GeographicAddressData>(b, table, x => x.AddressID, x => x.Address);
               createForeignKey<TelecomDeviceRegistrationData, TelecomAddressData>(b, table, x => x.DeviceID, x => x.Device);
           }
           internal static void createNationalCurrencyTable(ModelBuilder b)
           {
               const string table = "NationalCurrency";
               createPrimaryKey<NationalCurrencyData>(b, table, a => new { a.CountryID, a.CurrencyID });
               createForeignKey<NationalCurrencyData, CountryData>(b, table, x => x.CountryID, x => x.Country);
               createForeignKey<NationalCurrencyData, CurrencyData>(b, table, x => x.CurrencyID, x => x.Currency);
           }

        internal static void createPrimaryKey<TEntity>(ModelBuilder b, string tableName,
            Expression<Func<TEntity, object>> primaryKey) where TEntity : class
        {
            b.Entity<TEntity>()
                .ToTable(tableName)
                .HasKey(primaryKey);
        }
        internal static void createForeignKey<TEntity, TRelatedEntity>(ModelBuilder b,
            string tableName, Expression<Func<TEntity, object>> foreignKey,
            Expression<Func<TEntity, TRelatedEntity>> getRelatedEntity)
            where TEntity : class where TRelatedEntity : class
        {
            b.Entity<TEntity>()
                .ToTable(tableName)
                .HasOne(getRelatedEntity)
                .WithMany()
                .HasForeignKey(foreignKey)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
