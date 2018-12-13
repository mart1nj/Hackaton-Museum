using System.ComponentModel.DataAnnotations;
namespace Open.Core
{
    public enum MusealState
    {
        [Display(Name = "Hea")]
        Hea,
        [Display(Name = "Rahuldav")]
        Rahuldav,
        [Display(Name = "Määramata")]
        Määramata,
        [Display(Name = "Halb")]
        Halb,
        [Display(Name = "Väga halb")]
        VägaHalb
    }
}
