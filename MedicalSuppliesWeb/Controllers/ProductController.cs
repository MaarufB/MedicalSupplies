using Microsoft.AspNetCore.Mvc;
using MedicalSuppliesWeb.ViewModels.Product;
using MedicalSuppliesServices.Services.Contracts;
using MedicalSuppliesModels;

namespace MedicalSuppliesWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        [HttpGet]
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


        
            public IActionResult Details(int id)
            {
                // Retrieve the product by its ID from the database
                var product = _productRepo.GetProductById(id);

                if (product == null)
                {
                    // If the product is not found, return a not found view or redirect to another page
                    return NotFound();
                }

                // Map the product entity to a view model
                var productViewModel = new ProductVm
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Price = product.Price,
                    ManufacturerName = product.Manufacturer != null ? product.Manufacturer.ManufacturerName : null,
                    CategoryName = product.Category != null ? product.Category.CategoryName : null,
                    SupplierName = product.Supplier?.SupplierName
                };

                return View(productViewModel);
            }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Retrieve the product by its ID from the database
            var product = _productRepo.GetProductById(id);

            if (product == null)
            {
                // If the product is not found, return a not found view or redirect to another page
                return NotFound();
            }

            // Map the product entity to a view model (similar to what you did in the Details action)
            var productViewModel = new ProductVm
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                ManufacturerName = product.Manufacturer != null ? product.Manufacturer.ManufacturerName : null,
                CategoryName = product.Category != null ? product.Category.CategoryName : null,
                SupplierName = product.Supplier?.SupplierName
            };

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductVm editedProduct)
        {
            if (!ModelState.IsValid)
            {
                // If the model state is invalid, return the same edit view with validation errors
                return View(editedProduct);
            }

            // Retrieve the original product from the database
            var product = _productRepo.GetProductById(editedProduct.ProductId);

            if (product == null)
            {
                // If the product is not found, return a not found view or redirect to another page
                return NotFound();
            }

            // Update the properties of the original product entity with the edited values
            product.ProductName = editedProduct.ProductName;
            product.Description = editedProduct.Description;
            product.Price = editedProduct.Price;

            // If you have relationships like Manufacturer, Category, or Supplier, update them as well

            // Save the changes to the database
            //_productRepo.SaveChanges();

            // Redirect to the Details page or any other appropriate action after the update
            return RedirectToAction("Details", new { id = product.ProductId });
        }


        public IActionResult GetProductUnitPrice(Product product)
        {
            var unitPrice = _productRepo.GetProductUnitPrice(product);
            return Json(new { UnitPrice = unitPrice });

        }

    }
}
