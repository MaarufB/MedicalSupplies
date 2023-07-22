using MedicalSuppliesModels;

namespace MedicalSuppliesWeb.Services.Contracts
{
    public interface IInventoryRepo
    {
        public List<Inventory> GetInventories();
    }
}
