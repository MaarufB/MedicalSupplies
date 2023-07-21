using UserRolesModels;

namespace UserRolesNew.Services.Contracts
{
    public interface IProductRepo
    {
        public List<Product> GetAllProducts();
    }
}
