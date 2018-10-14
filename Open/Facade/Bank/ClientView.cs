using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Facade.Party;
using Open.Facade.Common;

namespace Open.Facade.Bank
{
    public class ClientView : EntityView {
        private string firstName = "Sonic";
        private string lastName = "The Hedgehog";
      //  private string geographicAddressID;
      //  private string emailAddressID;
        [Required]
        [DisplayName("First Name")]
        public string FirstName {
            get => getString(ref firstName);
            set => firstName = value;
        }

        [Required]
        [DisplayName("Last Name")]
        public string LastName {
            get => getString(ref lastName);
            set => lastName = value;
        }
        
        public GeographicAddressView GeographicAddress { get; set; } = new GeographicAddressView {
            AddressLine = "Sonicus road 5", City = "SonicTown", Country = "Estonia", RegionOrState = "Hedgehog state", ZipOrPostalCode = "12345"
        };
        public EMailAddressView EmailAddress { get; set; } = new EMailAddressView
            {EmailAddress = "sonicthehedgehog@sonicbank.com"};
    }
}

