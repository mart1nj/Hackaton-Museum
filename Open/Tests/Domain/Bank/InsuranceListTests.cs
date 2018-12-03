using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Bank;
using Open.Domain.Bank;
namespace Open.Tests.Domain.Bank
{
    [TestClass]
    public class InsuranceListTests : ListBaseTests<InsuranceList, Insurance>
    {
        protected override InsuranceList getRandomObject()
        {
            createWithNullArgs = new InsuranceList(null, null);
            var l = GetRandom.Object<List<InsuranceData>>();
            return new InsuranceList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}
