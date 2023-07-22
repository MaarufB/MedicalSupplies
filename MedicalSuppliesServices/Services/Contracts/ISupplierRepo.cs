using MedicalSuppliesModels;

namespace MedicalSuppliesServices.Services.Contracts
{
    public interface ISupplierRepo
    {
        public List<Supplier> GetAllSuppliers();
    }
}
