using Open.Core;
using System;

namespace Open.Data.Common {
    public abstract class ValueDbRecord : Archetype { }

    public abstract class ValueDbRecord<TAmount> : ValueDbRecord where TAmount : IConvertible {
        public TAmount Amount { get; set; }
    }
}