using System;
using Open.Core;
using Open.Data.Bank;
namespace Open.Domain.Bank
{
    public class TransactionFactory
    {
        public static ITransaction Create(BaseTransactionData data) {
            if (data is RequestTransactionData req)
                return create(req);
            return create(data as TransactionData);
        }
        private static RequestTransaction create(RequestTransactionData data)
        {
            return new RequestTransaction(data);
        }
        private static Transaction create(TransactionData data)
        {
            return new Transaction(data);
        }
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

        public static RequestTransaction CreateRequest(string id, decimal? amount, string explanation, string senderAccountId,
            string receiverAccountId, TransactionStatus status = TransactionStatus.Pending, DateTime? validFrom = null, DateTime? validTo = null) {
            var r = new RequestTransactionData
            {
                ID = id,
                Amount = amount,
                Explanation = explanation,
                Status = status,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue,
                SenderAccountId = senderAccountId,
                ReceiverAccountId = receiverAccountId
            };
            return new RequestTransaction(r);
        }
    }
}
