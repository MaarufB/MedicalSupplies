using Microsoft.AspNetCore.Mvc;
using UserRolesNew.Services.Contracts;
using UserRolesNew.ViewModels.Product;

namespace UserRolesNew.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public IActionResult Index()
        {

            var products = _productRepo.GetAllProducts();

            List<ProductVm> productViewModels = new List<ProductVm>();

            foreach (var p in products)
            {
                var productViewModel = new ProductVm
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Price = p.Price,
                    ManufacturerName = p.Manufacturer != null ? p.Manufacturer.ManufacturerName : null,
                    CategoryName = p.Category != null ? p.Category.CategoryName : null,
                    SupplierName = p.Supplier?.SupplierName
                };

                productViewModels.Add(productViewModel);
            }

            return View(productViewModels);
        }
    }
}
