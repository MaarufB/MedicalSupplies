using System.ComponentModel.DataAnnotations;

namespace MedicalSuppliesWeb.ViewModels.Supplier
{
    public class SupplierNumberVm
    {
        public int SupplierNumberId { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }
    }
}
