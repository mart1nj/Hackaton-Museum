using System;
using System.Collections.Generic;
using System.Linq;
using Open.Data.Bank;

namespace Open.Infra.Bank {
    public static class TransactionsInitializer {
        public static void Initialize(SentryDbContext c) {
            c.Database.EnsureCreated();
            if (c.Transactions.Any()) return;
            var accounts = initAccounts(c);
            initTransactions(c, accounts);
            c.SaveChanges();
        }

        private static void initTransactions(SentryDbContext c, List<string> accounts) {
            var l = new List<string> {
                addTransaction(c, new TransactionData {
                    Amount = 15120.99,
                    ValidFrom = Convert.ToDateTime("12 Feb 2007"),
                    Explanation = "Makse",
                   // SenderAccount = new AccountData(), //TODO create account with appUser
                   // ReceiverAccount = new AccountData(), //TODO create account with appUser
                    SenderAccountId = accounts[0],
                    ReceiverAccountId = accounts[1]
                }),
                addTransaction(c, new TransactionData {
                    Amount = 200.10,
                    ValidFrom = Convert.ToDateTime("29 May 2012"),
                    Explanation = "Jürile õnne sünnipäevaks!",
                   /* SenderAccount = new AccountData(), //TODO create account with appUser
                    ReceiverAccount = new AccountData(), //TODO create account with appUser*/
                    SenderAccountId = accounts[0],
                    ReceiverAccountId = accounts[1]
                }),
                addTransaction(c, new TransactionData {
                    Amount = 864.46,
                    ValidFrom = Convert.ToDateTime("5 September 2018"),
                    Explanation = "Arve nr 35455",
                  /*  SenderAccount = new AccountData(), //TODO create account with appUser
                    ReceiverAccount = new AccountData(), //TODO create account with appUser*/
                    SenderAccountId = accounts[1],
                    ReceiverAccountId = accounts[0]
                })
            };
        }

        private static List<string> initAccounts(SentryDbContext c) {
            var l = new List<string> {
                addAccount(c, new AccountData {
                    Balance = 0,
                    ValidFrom = Convert.ToDateTime("5 September 2018"),
                    ValidTo = Convert.ToDateTime("5 September 2028"),
                    Type = "ISIC",
                    ApplicationUserId = "sonicSiilId",
                    Status = "Active"
                }),
                addAccount(c, new AccountData {
                    Balance = 0,
                    ValidFrom = Convert.ToDateTime("30 September 2018"),
                    ValidTo = Convert.ToDateTime("30 September 2028"),
                    Type = "SlugClub",
                    ApplicationUserId = "testUserid",
                    Status = "Active"
                })
            };
            return l;
        }

        private static string addTransaction(SentryDbContext c, TransactionData data) {
            data.ID = Guid.NewGuid().ToString();
            c.Transactions.Add(data);
            return data.ID;
        }
        private static string addAccount(SentryDbContext c, AccountData data)
        {
            data.ID = Guid.NewGuid().ToString();
            c.Accounts.Add(data);
            return data.ID;
        }
    }
}
