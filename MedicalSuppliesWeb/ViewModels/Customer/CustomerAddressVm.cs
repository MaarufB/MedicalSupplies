using MedicalSuppliesWeb.ViewModels.State;
using System.ComponentModel.DataAnnotations;

namespace MedicalSuppliesWeb.ViewModels.Customer
{
    public class CustomerAddressVm
    {
        public int CustomerAddressId { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "State is required")]
        public StateVm State { get; set; }

        public string City { get; set; }
        public string Zip { get; set; }
    }
}
