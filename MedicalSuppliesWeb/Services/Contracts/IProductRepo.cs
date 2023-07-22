using MedicalSuppliesModels;

namespace UserRolesNew.Services.Contracts
{
    public interface IProductRepo
    {
        public List<Product> GetAllProducts();
        public Product GetProductById(int id);
    }
}
