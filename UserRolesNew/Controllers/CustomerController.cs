using Microsoft.AspNetCore.Mvc;
using UserRolesNew.ViewModels.Customer;

namespace UserRolesNew.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            var viewModel = new CustomerOrderVm();
           
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult CreateOrder(CustomerOrderVm viewModel)
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






    }
}
