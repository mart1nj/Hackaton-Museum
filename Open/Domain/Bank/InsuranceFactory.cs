using System;
using Open.Data.Bank;
namespace Open.Domain.Bank
{
    public static class InsuranceFactory
    {
        public static Insurance CreateInsurance(string id, decimal? payment, string type, string status, string accountId, DateTime? validFrom = null, DateTime? validTo = null)
        {
            var r = new InsuranceData
            {
                ID = id,
                Payment = payment,
                Type = type,
                Status = status,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue,
                AccountId = accountId
            };
            return new Insurance(r);
        }
        
    }
}
