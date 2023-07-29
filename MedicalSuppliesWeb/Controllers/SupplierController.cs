using MedicalSuppliesWeb.ViewModels.Country;
using MedicalSuppliesWeb.ViewModels.State;
using MedicalSuppliesWeb.ViewModels.Supplier;
using Microsoft.AspNetCore.Mvc;
using MedicalSuppliesServices.Services.Contracts;
using MedicalSuppliesServices.Services.Repositories;
using MedicalSuppliesWeb.ViewModels.Customer;
using MedicalSuppliesModels;

namespace MedicalSuppliesWeb.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierRepo _supplierRepo;
        private readonly ISupplierOrderRepo _supplierOrderRepo;

        public SupplierController(ISupplierRepo supplierRepo, ISupplierOrderRepo supplierOrderRepo)
        {
            _supplierRepo = supplierRepo;
            _supplierOrderRepo = supplierOrderRepo; 

        }
        public IActionResult Index()
        {
            
            var suppliers = _supplierRepo.GetAllSuppliers();

            
            var supplierViewModels = suppliers.Select(supplier => new SupplierProfileVm
            {
                SupplierId = supplier.SupplierId,
                SupplierName = supplier.SupplierName,
                ContactName = supplier.ContactName,
                ContactEmail = supplier.ContactEmail,
                SupplierAddresses = supplier.SupplierAddresses.Select(address => new SupplierAddressVm
                {
                    SupplierAddressId = address.SupplierAddressId,
                    Address = address.Address,
                    City = address.City,
                    State = new StateVm
                    {
                        State = address.State.LongState
                    },
                    Country = new CountryVm
                    {
                        Country = address.Country.CountryName,
                    },
                    Zip = address.Zip
                }).ToList(),
                SupplierNumbers = supplier.SupplierNumbers.Select(number => new SupplierNumberVm
                {
                    
                    SupplierNumberId = number.SupplierNumberId,
                    PhoneNumber = number.PhoneNumber,
                }).ToList()
            }).ToList();

            
            return View(supplierViewModels);
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            var viewModel = new SupplierOrderVm();

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult CreateOrder(SupplierOrderVm viewModel)
        {
            if (ModelState.IsValid)
            {
                // Perform necessary operations to save the customer order
                // You can access the submitted data through the viewModel parameter
                // Redirect to a success page or perform any other desired action
                return RedirectToAction("OrderSubmitted");
            }

            // If the model state is not valid, return to the create order view with the validation errors
            return View(viewModel);
        }



        [HttpGet]
        public IActionResult CreateInvoice()
        {
            var viewModel = new SupplierInvoiceVm();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateInvoice(SupplierInvoiceVm viewModel)
        {
            if (ModelState.IsValid)
            {
                // Perform necessary operations to save the customer order
                // You can access the submitted data through the viewModel parameter
                // Redirect to a success page or perform any other desired action
                return RedirectToAction("InvoiceSubmitted");
            }

            // If the model state is not valid, return to the create order view with the validation errors
            return View(viewModel);
        }


        [HttpGet]
        public IActionResult GetSupplierDetails(int supplierId)
        {
            var supplier = _supplierRepo.GetSupplierById(supplierId);
            if (supplier != null)
            {
                
                return Json(new { supplierName = supplier.SupplierName });
            }

            
            return Json(null);
        }


        [HttpGet]
        public IActionResult GetSupplierOrderDetails(int supplierOrderId)
        {
            var supplierOrder = _supplierOrderRepo.GetSupplierOrderDetails(supplierOrderId);

            if (supplierOrder == null)
            {
                return NotFound();
            }


            var supplierOrderVm = new SupplierOrderVm
            {
                SupplierOrderId = supplierOrder.SupplierOrderId,
                Date = supplierOrder.Date,
                SupplierOrderTotal = supplierOrder.SupplierOrderTotal,
                OrderStatus = supplierOrder.OrderStatus,
                SupplierId = supplierOrder.SupplierId,
                SupplierName = supplierOrder.Supplier.SupplierName,
                ShippingAddress = supplierOrder.ShippingAddress,
                BillingAddress = supplierOrder.BillingAddress,
                TaxRate = supplierOrder.TaxRate,
                TaxAmount = supplierOrder.TaxAmount,

                GrandTotal = supplierOrder.GrandTotal,

                SupplierOrderItems = new List<SupplierOrderItemVm>()
            };


            foreach (var supplierOrderItem in supplierOrder.SupplierOrderItems)
            {
                var supplierOrderItemVm = new SupplierOrderItemVm
                {

                    ProductName = supplierOrderItem.Product.ProductName,
                    Quantity = supplierOrderItem.Quantity,
                    UnitPrice = supplierOrderItem.UnitPrice,
                    LineTotal = supplierOrderItem.LineTotal
                };

                supplierOrderVm.SupplierOrderItems.Add(supplierOrderItemVm);
            }

            return Json(supplierOrderVm);


        }



        [HttpGet]
        public IActionResult Create()
        {
            // Create a new instance of the SupplierProfileVm view model
            var supplierViewModel = new SupplierProfileVm();

            return View(supplierViewModel);
        }

        [HttpPost]
        public IActionResult Create(SupplierProfileVm newSupplier)
        {
            if (!ModelState.IsValid)
            {
                // If the model state is invalid, return the same view with validation errors
                return View(newSupplier);
            }

            // Create a new Supplier entity based on the data in the view model
            var newSupplierEntity = new Supplier
            {
                SupplierName = newSupplier.SupplierName,
                ContactName = newSupplier.ContactName,
                ContactEmail = newSupplier.ContactEmail
            };

            // Save the new supplier entity to the database
            // _supplierRepo.AddSupplier(newSupplierEntity);
            // _supplierRepo.SaveChanges();

            // Redirect to the Details page for the newly created supplier or any other appropriate action
            return RedirectToAction("Details", new { id = newSupplierEntity.SupplierId });
        }



    }
}
