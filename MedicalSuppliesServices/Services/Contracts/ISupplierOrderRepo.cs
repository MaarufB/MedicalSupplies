using MedicalSuppliesModels;

namespace MedicalSuppliesServices.Services.Contracts
{
    public interface ISupplierOrderRepo
    {
        public List<SupplierOrder> GetAllSupplierOrders();
        public SupplierOrder GetSupplierOrderDetails(int supplierOrderId);
    }
}
