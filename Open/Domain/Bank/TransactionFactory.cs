using System;
using Open.Data.Bank;
namespace Open.Domain.Bank
{
    public class TransactionFactory
    {
        public static Transaction CreateTransaction(string id, decimal? amount, string explanation, string senderAccountId,
            string receiverAccountId, DateTime? validFrom = null, DateTime? validTo = null)
        {
            var r = new TransactionData
            {
                ID = id,
                Amount = amount,
                Explanation = explanation,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue,
                SenderAccountId = senderAccountId,
                ReceiverAccountId = receiverAccountId
            };
            return new Transaction(r);
        }

     /*   public static Transaction CreateTransaction(TransactionData transaction)
        {
            var r = new TransactionData
            {
                ID = transaction.ID,
                Amount = transaction.Amount,
                Explanation = transaction.Explanation,
                ValidFrom = transaction.ValidFrom,
                ValidTo = transaction.ValidTo,
                SenderAccountId = transaction.SenderAccountId,
                ReceiverAccountId = transaction.ReceiverAccountId
            };
            return new Transaction(r);
        }*/
    }
}
