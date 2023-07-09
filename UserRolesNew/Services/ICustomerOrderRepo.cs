using UserRolesModels;

namespace UserRolesNew.Services
{
    public interface ICustomerOrderRepo
    {
        public List<CustomerOrder> GetAllCustomerOrders();
    }
}
