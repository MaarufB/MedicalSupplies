using MedicalSuppliesWeb.Services.Contracts;
using MedicalSuppliesWeb.ViewModels.Country;
using MedicalSuppliesWeb.ViewModels.State;
using MedicalSuppliesWeb.ViewModels.Supplier;
using Microsoft.AspNetCore.Mvc;

using MedicalSuppliesWeb.ViewModels.Supplier;

namespace MedicalSuppliesWeb.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierRepo _supplierRepo;

        public SupplierController(ISupplierRepo supplierRepo)
        {
            _supplierRepo = supplierRepo;
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


    }
}
