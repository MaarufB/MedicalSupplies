using Microsoft.AspNetCore.Mvc;
using UserRolesNew.Services.Contracts;
using UserRolesNew.ViewModels.Customer;

namespace UserRolesNew.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public IActionResult Index()
        {
            var customers = _customerRepo.GetAllCustomers();

            var customerProfiles = customers.Select(customer => new CustomerProfileVm
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DOB = customer.DOB,
                Height = customer.Height,
                Weight = customer.Weight,
                Gender = new CustomerGenderVm
                {
                    GenderId = customer.Gender.GenderId,
                    GenderName = customer.Gender.GenderName
                },
                CustomerAddresses = customer.CustomerAddresses.Select(address => new CustomerAddressVm
                {
                    CustomerAddressId = address.AddressId,
                    Address = address.Address,
                    City = address.City,
                    State = address.State.LongState,
                    PostalCode = address.Zip
                }).ToList(),
                CustomerNumbers = customer.CustomerNumbers.Select(number => new CustomerNumberVm
                {
                    CustomerNumberId = number.CustomerNumberId,
                    PhoneNumber = number.PhoneNumber
                }).ToList(),
                Insurances = customer.Insurances.Select(insurance => new CustomerInsuranceVm
                {
                    InsuranceId = insurance.InsuranceId,
                    CustomerId = insurance.CustomerId,
                    InsuranceTypeId = insurance.InsuranceTypeId,
                    GroupId = insurance.GroupId,
                    PolicyNo = insurance.PolicyNo,
                    PrimaryInsurance = insurance.PrimaryInsurance,
                    SecondaryInsurance = insurance.SecondaryInsurance,
                    DateEffective = insurance.DateEffective,
                    DateExpire = insurance.DateExpire,
                    InsuranceType = new CustomerInsuranceTypeVm
                    {
                        InsuranceTypeId = insurance.InsuranceType.InsuranceTypeId,
                        Description = insurance.InsuranceType.Description
                    }
                }).ToList()
            }).ToList();

            return View(customerProfiles);
        }



        [HttpGet]
        public IActionResult Create()
        {
            var customerProfile = new CustomerProfileVm();
            return View(customerProfile);
        }

        [HttpPost]
        public IActionResult Create(CustomerProfileVm viewModel)
        {
            if (ModelState.IsValid)
            {
                // Perform necessary operations to save the customer profile
                // You can access the submitted data through the viewModel parameter

                // Redirect to a success page or perform any other desired action
                return RedirectToAction("Index");
            }

            // If the model state is not valid, return to the create view with the validation errors
            return View(viewModel);
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



        [HttpGet]
        public IActionResult CreateInvoice()
        {
            var viewModel = new CustomerInvoiceVm();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateInvoice(CustomerInvoiceVm viewModel)
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
