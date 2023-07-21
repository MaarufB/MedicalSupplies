using System.ComponentModel.DataAnnotations;

namespace UserRolesNew.ViewModels.Customer
{
    public class CustomerProfileVm
    {
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

        public ICollection<CustomerAddressVm> CustomerAddresses { get; set; }

        public ICollection<CustomerNumberVm> CustomerNumbers { get; set; }

        public ICollection<CustomerInsuranceVm> Insurances { get; set; }
    }
}
