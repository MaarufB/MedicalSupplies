using Microsoft.AspNetCore.Mvc;

using UserRolesNew.ViewModels.Supplier;

namespace UserRolesNew.Controllers
{
    public class SupplierController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
