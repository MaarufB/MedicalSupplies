using System.ComponentModel.DataAnnotations;

namespace MedicalSuppliesWeb.ViewModels.Customer
{
    public class CustomerProfileVm
    {
        public CustomerProfileVm()
        {
            CustomerAddresses = new List<CustomerAddressVm>();
            CustomerNumbers = new List<CustomerNumberVm>();
            Insurances = new List<CustomerInsuranceVm>();
        }
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DOB { get; set; }

        public string Height { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        public int Weight { get; set; }

        public CustomerGenderVm Gender { get; set; }

        public CustomerInsuranceVm InsuranceDetails { get; set; } = new CustomerInsuranceVm();

        public List<CustomerAddressVm>? CustomerAddresses { get; set; }

        public List<CustomerNumberVm> CustomerNumbers { get; set; }

        public List<CustomerInsuranceVm> Insurances { get; set; }
    }
}
