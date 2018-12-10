using System;
using System.Collections.Generic;
using System.Linq;
using Open.Core;
using Open.Data.Bank;

namespace Open.Infra.Bank {
    public static class TransactionsInitializer {
        private static decimal amount1 = (decimal) 15120.99;
        private static decimal amount2 = (decimal) 200.10;
        private static decimal amount3 = (decimal) 864.46;
        private static decimal amount4 = 100;
        private static decimal amount5 = 50;

        public static void Initialize(ApplicationDbContext c) {
            c.Database.EnsureCreated();
            if (c.Transactions.Any()) return;
            var accounts = initAccounts(c);
            c.SaveChanges();
            initTransactions(c, accounts);
            c.SaveChanges();
        }

        private static void initBaseTransactions(ApplicationDbContext c, List<string> accounts)
        {
            addTransaction(c, new TransactionData
            {
                Amount = 500,
                ValidFrom = Convert.ToDateTime("12 Feb 2007"),
                Explanation = "Makse",
                SenderAccountId = accounts[0],
                ReceiverAccountId = accounts[1]
            });
        }

        private static void initTransactions(ApplicationDbContext c, List<string> accounts) {
            addTransaction(c, new TransactionData {
                Amount = amount1,
                ValidFrom = Convert.ToDateTime("12 Feb 2007"),
                Explanation = "Makse",
                SenderAccountId = accounts[0],
                ReceiverAccountId = accounts[1]
            });
            addTransaction(c, new TransactionData {
                Amount = amount2,
                ValidFrom = Convert.ToDateTime("29 May 2012"),
                Explanation = "Jürile õnne sünnipäevaks!",
                SenderAccountId = accounts[0],
                ReceiverAccountId = accounts[1]
            });
            addTransaction(c, new TransactionData {
                Amount = amount3,
                ValidFrom = Convert.ToDateTime("5 September 2018"),
                Explanation = "Arve nr 35455",
                SenderAccountId = accounts[1],
                ReceiverAccountId = accounts[0]
            });
            addTransaction(c, new TransactionData {
                Amount = amount4,
                ValidFrom = Convert.ToDateTime("3 November 2018"),
                Explanation = "Tere tulemast!",
                SenderAccountId = accounts[0],
                ReceiverAccountId = accounts[2]
            });
            addTransaction(c, new TransactionData {
                Amount = amount5,
                ValidFrom = Convert.ToDateTime("3 November 2018"),
                Explanation = "Võlg",
                SenderAccountId = accounts[0],
                ReceiverAccountId = accounts[2]
            });
        }

        private static List<string> initAccounts(ApplicationDbContext c) {
            var systemAccount = new AccountData {
                ID = "systemAccount",
                Balance = 1000000,
                ValidFrom = Convert.ToDateTime("7 November 2018"),
                ValidTo = DateTime.MaxValue,
                Type = "System",
                AspNetUserId = "system",
                Status = "Active"
            };
            c.Add(systemAccount);
            var l = new List<string> {
                addAccount(c, new AccountData {
                    Balance = -amount1 - amount2 + amount3 - amount4 - amount5,
                    ValidFrom = Convert.ToDateTime("5 September 2018"),
                    ValidTo = Convert.ToDateTime("5 September 2028"),
                    Type = "ISIC",
                    AspNetUserId = "sonicSiilId",
                    Status = "Active"
                }),
                addAccount(c, new AccountData {
                    Balance = amount1 + amount2 - amount3,
                    ValidFrom = Convert.ToDateTime("30 September 2018"),
                    ValidTo = Convert.ToDateTime("30 September 2028"),
                    Type = "SlugClub",
                    AspNetUserId = "testUserid",
                    Status = "Active"
                }),
                addAccount(c, new AccountData {
                    Balance = amount4 + amount5,
                    ValidFrom = Convert.ToDateTime("3 November 2018"),
                    ValidTo = Convert.ToDateTime("30 September 2028"),
                    Type = "Debit",
                    AspNetUserId = "testUserid",
                    Status = "Active"
                }),
            };
            return l;
        }

        private static void addTransaction(ApplicationDbContext c, TransactionData data) {
            data.ID = Guid.NewGuid().ToString();
            c.Transactions.Add(data);
        }

        private static string addAccount(ApplicationDbContext c, AccountData data) {
            data.ID = BankId.NewBankId();
            c.Accounts.Add(data);
            return data.ID;
        }
    }
}
