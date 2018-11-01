using System;
using System.Collections.Generic;
using System.Linq;
using Open.Data.Bank;

namespace Open.Infra.Bank {
    public static class TransactionsInitializer {
        private static double amount1 = 15120.99;
        private static double amount2 = 200.10;
        private static double amount3 = 864.46;

        public static void Initialize(ApplicationDbContext c) {
            c.Database.EnsureCreated();
            if (c.Transactions.Any()) return;
            var accounts = initAccounts(c);
            c.SaveChanges();
            initTransactions(c, accounts);
            c.SaveChanges();
        }

        private static void initTransactions(ApplicationDbContext c, List<string> accounts) {
            var l = new List<string> {
                addTransaction(c, new TransactionData {
                    Amount = amount1,
                    ValidFrom = Convert.ToDateTime("12 Feb 2007"),
                    Explanation = "Makse",
                    SenderAccountId = accounts[0],
                    ReceiverAccountId = accounts[1]
                }),
                addTransaction(c, new TransactionData {
                    Amount = amount2,
                    ValidFrom = Convert.ToDateTime("29 May 2012"),
                    Explanation = "Jürile õnne sünnipäevaks!",
                    SenderAccountId = accounts[0],
                    ReceiverAccountId = accounts[1]
                }),
                addTransaction(c, new TransactionData {
                    Amount = amount3,
                    ValidFrom = Convert.ToDateTime("5 September 2018"),
                    Explanation = "Arve nr 35455",
                    SenderAccountId = accounts[1],
                    ReceiverAccountId = accounts[0]
                })
            };
        }

        private static List<string> initAccounts(ApplicationDbContext c) {
            var l = new List<string> {
                addAccount(c, new AccountData {
                    Balance = -amount1 - amount2 + amount3,
                    ValidFrom = Convert.ToDateTime("5 September 2018"),
                    ValidTo = Convert.ToDateTime("5 September 2028"),
                    Type = "ISIC",
                    AspnetUserId = "sonicSiilId",
                    Status = "Active"
                }),
                addAccount(c, new AccountData {
                    Balance = amount1 + amount2 - amount3,
                    ValidFrom = Convert.ToDateTime("30 September 2018"),
                    ValidTo = Convert.ToDateTime("30 September 2028"),
                    Type = "SlugClub",
                    AspnetUserId = "testUserid",
                    Status = "Active"
                })
            };
            return l;
        }

        private static string addTransaction(ApplicationDbContext c, TransactionData data) {
            data.ID = Guid.NewGuid().ToString();
            c.Transactions.Add(data);
            return data.ID;
        }
        private static string addAccount(ApplicationDbContext c, AccountData data)
        {
            data.ID = Guid.NewGuid().ToString();
            c.Accounts.Add(data);
            return data.ID;
        }
    }
}
