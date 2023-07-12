using UserRolesModels;

namespace UserRolesNew.Services.Contracts
{
    public interface IInventoryRepo
    {
        public List<Inventory> GetInventories();
    }
}
