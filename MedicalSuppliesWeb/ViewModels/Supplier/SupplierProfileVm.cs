using System.ComponentModel.DataAnnotations;

namespace MedicalSuppliesWeb.ViewModels.Supplier
{
    public class SupplierProfileVm
    {
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Supplier Name is required")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "Contact Name is required")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Contact Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ContactEmail { get; set; }

        // Properties related to SupplierAddress
        public ICollection<SupplierAddressVm> SupplierAddresses { get; set; }

        // Properties related to SupplierNumber
        public ICollection<SupplierNumberVm> SupplierNumbers { get; set; }
    }
}
