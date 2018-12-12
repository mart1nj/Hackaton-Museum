using System.ComponentModel.DataAnnotations;
using Open.Aids;
namespace Open.Facade.Common
{
    public class MetricsView : NamedView
    {
        private string code;
        private string id;
        private string definition;
        [Required]
        [StringLength(10, MinimumLength = 3)]
        [RegularExpression(RegularExpressionFor.EnglishCapitalsOnly)]
        public string ID
        {
            get => getString(ref id);
            set => id = value;
        }

        public string Code
        {
            get => getString(ref code);
            set => code = value;
        }

        public string Definition
        {
            get => getString(ref definition);
            set => definition = value;
        }
    }
}
