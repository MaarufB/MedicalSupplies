using UserRolesModels;

namespace UserRolesNew.Services
{
    public interface ISupplierOrderRepo
    {
        public List<SupplierOrder> GetAllSupplierOrders();
    }
}
