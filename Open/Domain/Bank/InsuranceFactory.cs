using System;
using Open.Data.Bank;
namespace Open.Domain.Bank
{
    public static class InsuranceFactory
    {
        public static Insurance CreateInsurance(string id, decimal? payment, string type, string status, string applicationUserId, DateTime? validFrom = null, DateTime? validTo = null)
        {
            var r = new InsuranceData
            {
                ID = id,
                Payment = payment,
                Type = type,
                Status = status,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue,
                AspNetUserId = applicationUserId
            };
            return new Insurance(r);
        }
        
    }
}
