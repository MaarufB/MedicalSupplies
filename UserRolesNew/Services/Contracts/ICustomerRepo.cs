using UserRolesModels;

namespace UserRolesNew.Services.Contracts
{
    public interface ICustomerRepo
    {
        public List<Customer> GetAllCustomers();
    }
}
