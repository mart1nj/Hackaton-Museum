using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Core;
using Open.Facade.Bank;

namespace Open.Facade.Bank
{
    public class RequestTransacionView : TransactionView
    {
        public Status status { get; set; }
    }
}
