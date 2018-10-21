using System;
using System.Collections.Generic;
using System.Linq;
using Open.Data.Bank;
using Open.Data.Quantity;

namespace Open.Infra.Bank {
    public static class TransactionsInitializer {
        public static void Initialize(SentryDbContext c) {
            c.Database.EnsureCreated();
            if (c.Transactions.Any()) return;
            initTransactions(c);
            c.SaveChanges();
        }

        private static List<string> initTransactions(SentryDbContext c) {
            var l = new List<string> {
                add(c, new TransactionData {
                    Amount = 15120,
                    DateMade = Convert.ToDateTime("12 Feb 2007"),
                    Explanation = "Makse",
                    TransactionAccountNr = "12345",
                    PaymentMethod = new PaymentMethodData(),
                    ApplicationUser = new ApplicationUser()
                }),
                add(c, new TransactionData {
                    Amount = 200,
                    DateMade = Convert.ToDateTime("29 May 2012"),
                    Explanation = "Jürile õnne sünnipäevaks!",
                    TransactionAccountNr = "52342",
                    PaymentMethod = new PaymentMethodData(),
                    ApplicationUser = new ApplicationUser()
                }),
                add(c, new TransactionData {
                    Amount = 864,
                    DateMade = Convert.ToDateTime("5 September 2018"),
                    Explanation = "Arve nr 35455",
                    TransactionAccountNr = "78821",
                    PaymentMethod = new PaymentMethodData(),
                    ApplicationUser = new ApplicationUser()
                })
            };

            return l;
        }

        private static string add(SentryDbContext c, TransactionData data) {
            data.ID = Guid.NewGuid().ToString();
            c.Transactions.Add(data);
            return data.ID;
        }
    }
}
