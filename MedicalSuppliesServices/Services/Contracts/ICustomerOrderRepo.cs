using MedicalSuppliesModels;

namespace MedicalSuppliesServices.Services.Contracts
{
    public interface ICustomerOrderRepo
    {
        public List<CustomerOrder> GetAllCustomerOrders();
    }
}
