using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Bank;
using Open.Domain.Bank;
namespace Open.Tests.Domain.Bank
{
    [TestClass]
    public class AccountListTests : ListBaseTests<AccountList, Account>
    {
        protected override AccountList getRandomObject()
        {
            createWithNullArgs = new AccountList(null, null);
            var l = GetRandom.Object<List<AccountData>>();
            return new AccountList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}

