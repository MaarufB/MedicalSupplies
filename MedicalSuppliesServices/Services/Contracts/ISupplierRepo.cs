using MedicalSuppliesModels;

namespace MedicalSuppliesServices.Services.Contracts
{
    public interface ISupplierRepo
    {
        public List<Supplier> GetAllSuppliers();
        public Supplier GetSupplierById(int supplierId);
    }
}
