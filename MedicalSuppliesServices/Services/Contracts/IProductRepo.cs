using MedicalSuppliesModels;

namespace MedicalSuppliesServices.Services.Contracts
{
    public interface IProductRepo
    {
        public List<Product> GetAllProducts();
        public Product GetProductById(int id);
        public decimal GetProductUnitPrice(Product product);
    }
}
