using MedicalSuppliesModels;

namespace MedicalSuppliesWeb.Services.Contracts
{
    public interface ISupplierOrderRepo
    {
        public List<SupplierOrder> GetAllSupplierOrders();
    }
}
