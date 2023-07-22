using MedicalSuppliesWeb.ViewModels.Country;
using MedicalSuppliesWeb.ViewModels.State;
using System.ComponentModel.DataAnnotations;


namespace MedicalSuppliesWeb.ViewModels.Supplier
{
    public class SupplierAddressVm
    {
        public int SupplierAddressId { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public StateVm State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public CountryVm Country { get; set; }

        [Required(ErrorMessage = "Zip is required")]
        public string Zip { get; set; }
    }
}
