using System.Net;
using MedicalSuppliesModels;
using MedicalSuppliesWeb.ViewModels.State;

namespace MedicalSuppliesWeb.Services.Contracts
{
    public interface ICustomerRepo
    {
        public List<Customer> GetAllCustomers();

        public void AddCustomer(Customer customer);

        public void AddCustomerAddress(CustomerAddress address);

        public int GetStateIdByName(StateVm state);

        public void AddCustomerNumber(CustomerNumber number);

        public void AddCustomerInsurance(Insurance insurance);
    }
}
