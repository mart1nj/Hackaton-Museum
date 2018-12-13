using System.ComponentModel.DataAnnotations;
namespace Open.Core
{
    public enum MusealState
    {
        [Display (Name="Väga hea")]
        VeryGood,
        [Display(Name = "Hea")]
        Good,
        [Display(Name = "Määramata")]
        Unspecified,
        [Display(Name = "Halb")]
        Bad,
        [Display(Name = "Väga halb")]
        VeryBad
    }
}
