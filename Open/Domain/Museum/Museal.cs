using System.Collections.Generic;
using Open.Core;
using Open.Data.Museum;
using Open.Domain.Common;
namespace Open.Domain.Museum
{
    public sealed class Museal : Entity<MusealData>
    {
        public Museal(MusealData r) : base(r ?? new MusealData()) { }
    }
}


