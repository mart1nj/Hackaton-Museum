using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Core;

namespace Open.Data.Bank
{
    public class RequestTransactionData : TransactionData
    {
        public Status Status { get; set; }
    }
}
