using Microsoft.AspNetCore.Mvc;
using MedicalSuppliesWeb.ViewModels.Product;
using MedicalSuppliesServices.Services.Contracts;
using MedicalSuppliesModels;

namespace MedicalSuppliesWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _productRepo;
        private readonly IManufacturerRepo _manufacturerRepo;
        private readonly ISupplierRepo _supplierRepo;
        private readonly IColourRepo _colourRepo;
        private readonly ICategoryRepo _categoryRepo;

        public ProductController(IProductRepo productRepo, IManufacturerRepo manufacturerRepo, ISupplierRepo supplierRepo, IColourRepo colourRepo, ICategoryRepo categoryRepo)
        {
            _productRepo = productRepo;
            _manufacturerRepo = manufacturerRepo;  
            _supplierRepo = supplierRepo;
            _colourRepo = colourRepo;
            _categoryRepo = categoryRepo;

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
                
                var product = _productRepo.GetProductById(id);

                if (product == null)
                {
                    
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


        [HttpGet]
        public IActionResult Create()
        {
            // Load data for dropdown lists from the database
            var manufacturers = _manufacturerRepo.GetAllManufacturers();
            var suppliers = _supplierRepo.GetAllSuppliers();
            var colours = _colourRepo.GetAllColours();
            var categories = _categoryRepo.GetAllCategories();

            // Create a new instance of the ProductVm view model and populate the available options
            var productViewModel = new ProductVm
            {
                AvailableManufacturers = manufacturers.ToList(),
                AvailableSuppliers = suppliers.ToList(),
                AvailableColours = colours.ToList(),
                AvailableCategories = categories.ToList()
            };

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductVm newProduct)
        {
            if (!ModelState.IsValid)
            {
                
                var manufacturers = _manufacturerRepo.GetAllManufacturers();
                var suppliers = _supplierRepo.GetAllSuppliers();
                var colours = _colourRepo.GetAllColours();
                var categories = _categoryRepo.GetAllCategories();

                newProduct.AvailableManufacturers = manufacturers.ToList();
                newProduct.AvailableSuppliers = suppliers.ToList();
                newProduct.AvailableColours = colours.ToList();
                newProduct.AvailableCategories = categories.ToList();

                return View(newProduct);
            }

            // Create a new Product entity based on the data in the view model
            var newProductEntity = new Product
            {
                ProductName = newProduct.ProductName,
                Description = newProduct.Description,
                Price = newProduct.Price,
                ManufacturerId = newProduct.ManufacturerId,
                SupplierId = newProduct.SupplierId,
                ColourId = newProduct.ColourId,
                CategoryId = newProduct.CategoryId
            };

            // Save the new product entity to the database
            //_productRepo.AddProduct(newProductEntity);
            //_productRepo.SaveChanges();

            // Redirect to the Details page for the newly created product or any other appropriate action
            return RedirectToAction("Details", new { id = newProductEntity.ProductId });
        }


    }
}
