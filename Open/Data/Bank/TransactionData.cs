using Open.Data.Common;

namespace Open.Data.Bank
{
    public class TransactionData : IdentifiedData {

        private string explanation;
        private string sAccountId;
        private string rAccountId;
        
        public double Amount { get; set; }      
        
        public string Explanation {
            get => getString(ref explanation);
            set => explanation = value;
        }
        public string SenderAccountId
        {
            get => getString(ref sAccountId);
            set => sAccountId = value;
        }
        public string ReceiverAccountId
        {
            get => getString(ref rAccountId);
            set => rAccountId = value;
        }
        
        public virtual AccountData SenderAccount { get; set; }
        public virtual AccountData ReceiverAccount { get; set; }
    }
}
