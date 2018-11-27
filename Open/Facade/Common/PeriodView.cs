using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Core;
namespace Open.Facade.Common {
    public abstract class PeriodView : Archetype {
        [DataType(DataType.Date)]
        [DisplayName("Valid From")]
        public virtual DateTime? ValidFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Valid To")]
        public virtual DateTime? ValidTo { get; set; }

    }
}


