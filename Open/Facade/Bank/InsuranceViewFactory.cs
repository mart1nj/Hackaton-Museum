using System;
using Open.Aids;
using Open.Data.Bank;
using Open.Domain.Bank;
namespace Open.Facade.Bank
{
    public class InsuranceViewFactory
    {
        public static InsuranceView Create(Insurance o)
        {
            var v = new InsuranceView
            {
                Type = o?.Data.Type,
                Status = o?.Data.Status,
                Payment = o?.Data.Payment ?? (decimal?) 0.0,
                ID = o?.Data?.ID,
                AccountId = o?.Data?.AccountId
            };
            if (o is null) return v;
            v.ValidFrom = Date.SetNullIfMaxOrMin(o.Data.ValidFrom);
            v.ValidTo = Date.SetNullIfMaxOrMin(o.Data.ValidTo);
            return v;
        }
        
        public static Insurance Create(InsuranceView v)
        {
            var r = new InsuranceData
            {
                Payment = v?.Payment?? (decimal?) 0.0,
                Type = v?.Type,
                Status= v?.Status,
                ValidFrom = v?.ValidFrom ?? DateTime.MinValue,
                ValidTo = v?.ValidTo?? DateTime.MaxValue,
                ID = v?.ID,
                AccountId = v?.AccountId
            };
            return new Insurance(r);
        }
    }
}
