using MedicalSuppliesModels;

namespace MedicalSuppliesWeb.Services.Contracts
{
    public interface ISupplierRepo
    {
        public List<Supplier> GetAllSuppliers();
    }
}
