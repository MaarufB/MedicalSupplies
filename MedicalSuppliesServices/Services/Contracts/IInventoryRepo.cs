using MedicalSuppliesModels;

namespace MedicalSuppliesServices.Services.Contracts
{
    public interface IInventoryRepo
    {
        public List<Inventory> GetInventories();
    }
}
