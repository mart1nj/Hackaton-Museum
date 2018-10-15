using System;
using Open.Aids;
using Open.Data.Bank;
using Open.Domain.Bank;

namespace Open.Facade.Bank
{
    public class TransactionViewFactory
    {
        public static TransactionView Create(Transaction o) {
            var v = new TransactionView() {
                Amount = o?.Amount?.Amount ?? 0,
                Explanation = o?.Data.Explanation,
                ID = o?.Data?.ID
            };
            if (o is null) return v;
            v.DateMade = Date.SetNullIfMaxOrMin(o.Data.DateMade);
            v.ValidTo = Date.SetNullIfMaxOrMin(o.Data.ValidTo);
            return v;
        }
        public static Transaction Create(TransactionView v) {
            var r = new TransactionData{
                Amount = v?.Amount ?? 0,
                Explanation = v?.CurrencyID,
                DateMade = v?.DateMade ?? DateTime.MinValue,
                ValidTo = v?.ValidTo ?? DateTime.MaxValue,
                ID = v?.ID
            };
            return new Transaction(r);
        }
    }
}