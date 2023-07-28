using Microsoft.EntityFrameworkCore;
using MedicalSuppliesModels;
using MedicalSuppliesModels.Context;
using MedicalSuppliesServices.Services.Contracts;

namespace MedicalSuppliesServices.Services.Repositories
{
    public class Productrepo : IProductRepo
    {
        private readonly MSDBContext _context;

        public Productrepo(MSDBContext context)
        {
            _context = context;
        }
        public List<Product> GetAllProducts()
        {
            var products = _context.Products
                .Include(p => p.Category)
                .Include(s => s.Supplier)
                .Include(m => m.Manufacturer)
                .Include(c => c.Colour).ToList();
            return products;
        }

        public Product GetProductById(int id)
        {
            var product = _context.Products
        .Include(p => p.Manufacturer) 
        .Include(p => p.Supplier)     
        .Include(p => p.Category)     
        .FirstOrDefault(p => p.ProductId == id);

            return product;
        }

        public decimal GetProductUnitPrice(Product product)
        {
            var unitPrice = _context.Products.FirstOrDefault(p=>p.ProductName == product.ProductName);
            return unitPrice == null ? 0 : unitPrice.Price;
        }
    }
}
