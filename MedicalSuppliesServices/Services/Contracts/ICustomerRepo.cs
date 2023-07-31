using MedicalSuppliesModels;


namespace MedicalSuppliesServices.Services.Contracts
{
    public interface ICustomerRepo
    {
        public List<Customer> GetAllCustomers();

        public void AddCustomer(Customer customer);

        public void AddCustomerAddress(CustomerAddress address);

        public int GetStateIdByName(string state);

        public void AddCustomerNumber(CustomerNumber number);

        public void AddCustomerInsurance(Insurance insurance);

        public Customer GetCustomerById(int id);

        //public void UpdateCustomer(CustomerProfileVm customer);

        public void UpdateCustomer(Customer customer);
    }
}
