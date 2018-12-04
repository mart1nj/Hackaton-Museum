using Open.Aids;
using Open.Core;
using Open.Domain.Bank;

namespace Open.Facade.Bank
{
    public class TransactionViewFactory
    {
        public static TransactionView Create(Transaction o) {
            var v = new TransactionView {
                Amount = o?.Data.Amount ?? (decimal?) 0.0,
                Explanation = o?.Data.Explanation,
                ID = o?.Data?.ID,
                SenderAccountId = o?.Data.SenderAccountId,
                ReceiverAccountId = o?.Data.ReceiverAccountId
            };
            if (o is null) return v;
            v.ValidFrom = Date.SetNullIfMaxOrMin(o.Data.ValidFrom);
            v.ValidTo = Date.SetNullIfMaxOrMin(o.Data.ValidTo);
            return v;
        }
        /*      public static Transaction Create(TransactionView v) {
                  var r = new TransactionData{
                      Amount = v?.Amount ?? (decimal?) 0.0,
                      Explanation = v?.Explanation,
                      ID = v?.ID,
                      SenderAccountId = v?.SenderAccountId,
                      ReceiverAccountId = v?.ReceiverAccountId,
                      ValidFrom = v?.ValidFrom ?? DateTime.MinValue,
                      ValidTo = v?.ValidTo ?? DateTime.MaxValue,
                  };
                  return new Transaction(r);
              }*/
        public static RequestTransactionView Create(RequestTransaction o)
        {
            var v = new RequestTransactionView
            {
                Amount = o?.Data.Amount ?? (decimal?)0.0,
                Explanation = o?.Data.Explanation,
                ID = o?.Data?.ID,
                SenderAccountId = o?.Data.SenderAccountId,
                ReceiverAccountId = o?.Data.ReceiverAccountId,
                Status = o?.Data.Status ?? TransactionStatus.Pending
            };
            if (o is null) return v;
            v.ValidFrom = Date.SetNullIfMaxOrMin(o.Data.ValidFrom);
            v.ValidTo = Date.SetNullIfMaxOrMin(o.Data.ValidTo);
            return v;
        }
    }
}