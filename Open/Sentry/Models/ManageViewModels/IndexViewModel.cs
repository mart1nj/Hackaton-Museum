using System.ComponentModel.DataAnnotations;
using Open.Facade.Bank;
namespace Open.Sentry.Models.ManageViewModels
{
    public class IndexViewModel : ClientView
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
