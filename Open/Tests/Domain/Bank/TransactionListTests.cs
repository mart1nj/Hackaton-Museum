using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Bank;
using Open.Domain.Bank;
namespace Open.Tests.Domain.Bank
{
    [TestClass]
    public class TransactionListTests : ListBaseTests<TransactionList, Transaction>
    {
        protected override TransactionList getRandomObject()
        {
            createWithNullArgs = new TransactionList(null, null);
            var l = GetRandom.Object<List<TransactionData>>();
            return new TransactionList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}

