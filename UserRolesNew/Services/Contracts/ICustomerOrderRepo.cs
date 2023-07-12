using UserRolesModels;

namespace UserRolesNew.Services.Contracts
{
    public interface ICustomerOrderRepo
    {
        public List<CustomerOrder> GetAllCustomerOrders();
    }
}
