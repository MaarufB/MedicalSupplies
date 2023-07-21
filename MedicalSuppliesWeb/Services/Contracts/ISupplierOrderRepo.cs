using UserRolesModels;

namespace UserRolesNew.Services.Contracts
{
    public interface ISupplierOrderRepo
    {
        public List<SupplierOrder> GetAllSupplierOrders();
    }
}
