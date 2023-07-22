using MedicalSuppliesModels;

namespace MedicalSuppliesWeb.Services.Contracts
{
    public interface ICustomerOrderRepo
    {
        public List<CustomerOrder> GetAllCustomerOrders();
    }
}
