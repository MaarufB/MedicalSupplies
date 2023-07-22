using MedicalSuppliesModels;

namespace Inventory_Dashboard.Services
{
    public interface IInventoryRepo
    {
        Task <List<Inventory>> GetAllInventory();
    }
}
