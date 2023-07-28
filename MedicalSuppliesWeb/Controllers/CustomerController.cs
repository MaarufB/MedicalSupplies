using Microsoft.AspNetCore.Mvc;
using MedicalSuppliesModels;
using MedicalSuppliesWeb.ViewModels.Customer;
using MedicalSuppliesWeb.ViewModels.State;
using MedicalSuppliesServices.Services.Contracts;

namespace MedicalSuppliesWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly ICustomerOrderRepo _customerOrderRepo;

        public CustomerController(ICustomerRepo customerRepo, ICustomerOrderRepo customerOrderRepo)
        {
            _customerRepo = customerRepo;
            _customerOrderRepo = customerOrderRepo;

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

                    State = new StateVm
                    {
                        Id = address.State.StateId,
                        State = address.State.LongState
                        
                    },
                    
                    Zip = address.Zip
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
                                
                var customer = new Customer
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    DOB = viewModel.DOB,
                    Height = viewModel.Height,
                    Weight = viewModel.Weight,

                    Gender = new Gender
                    {
                        GenderId = viewModel.Gender.GenderId,
                        GenderName = viewModel.Gender.GenderName
                    }

                };

                //customer.GenderId = viewModel.Gender.GenderId;

                
                _customerRepo.AddCustomer(customer);

                foreach (var addressVm in viewModel.CustomerAddresses)
                {
                    var stateId = _customerRepo.GetStateIdByName(addressVm.State.State);
                    var address = new CustomerAddress
                    {
                        Address = addressVm.Address,
                        City = addressVm.City,
                        StateId = stateId,
                        Zip = addressVm.Zip,
                        CustomerId = customer.CustomerId // this is needed to set the foreign key link to the customer table
                    };
                    
                    _customerRepo.AddCustomerAddress(address);
                }

                foreach (var numberVm in viewModel.CustomerNumbers)
                {
                    var number = new CustomerNumber
                    {
                        PhoneNumber = numberVm.PhoneNumber,
                        CustomerId = customer.CustomerId // for foreign key
                    };
                    _customerRepo.AddCustomerNumber(number);
                }

                foreach (var insuranceVm in viewModel.Insurances)
                {
                    var insurance = new Insurance
                    {
                        CustomerId = customer.CustomerId, // for foreign key
                        InsuranceTypeId = insuranceVm.InsuranceTypeId,
                        GroupId = insuranceVm.GroupId,
                        PolicyNo = insuranceVm.PolicyNo,
                        PrimaryInsurance = insuranceVm.PrimaryInsurance,
                        SecondaryInsurance = insuranceVm.SecondaryInsurance,
                        DateEffective = insuranceVm.DateEffective,
                        DateExpire = insuranceVm.DateExpire
                    };
                    _customerRepo.AddCustomerInsurance(insurance);
                }                
                return RedirectToAction("Index");
            }
            if (!ModelState.IsValid)
            {
                foreach (var modelStateValue in ModelState.Values)
                {
                    foreach (var error in modelStateValue.Errors)
                    {
                        var errorMessage = error.ErrorMessage;
                        
                    }
                }
            }


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

        [HttpGet]
        public IActionResult GetCustomerDetails(int customerId)
        {
            var customer = _customerRepo.GetCustomerById(customerId);
            if (customer != null)
            {
                // Return the customer details in JSON format
                return Json(new { firstName = customer.FirstName, lastName = customer.LastName });
            }

            // If customer is not found, return null in JSON format
            return Json(null);
        }


        [HttpGet]
        public IActionResult GetCustomerOrderDetails(int customerOrderId)
        {
            var customerOrder = _customerOrderRepo.GetCustomerOrderDetails(customerOrderId);

            if (customerOrder == null)
            {
                return NotFound();
            }

           
            var customerOrderVm = new CustomerOrderVm
            {
                CustomerOrderId = customerOrder.CustomerOrderId,
                Date = customerOrder.Date,
                CustomerOrderTotal = customerOrder.CustomerOrderTotal,
                OrderStatus = customerOrder.OrderStatus,
                CustomerId = customerOrder.CustomerId,
                CustomerName = customerOrder.Customer.FirstName,
                ShippingAddress = customerOrder.ShippingAddress,
                BillingAddress = customerOrder.BillingAddress,
                TaxRate = customerOrder.TaxRate,
                TaxAmount = customerOrder.TaxAmount,
              
                GrandTotal = customerOrder.GrandTotal,
                
                CustomerOrderItems = new List<CustomerOrderItemVm>()
            };

            
            foreach (var customerOrderItem in customerOrder.CustomerOrderItems)
            {
                var customerOrderItemVm = new CustomerOrderItemVm
                {
                    
                    ProductName = customerOrderItem.Product.ProductName,
                    Quantity = customerOrderItem.Quantity,
                    UnitPrice = customerOrderItem.UnitPrice,
                    LineTotal = customerOrderItem.LineTotal
                };

                customerOrderVm.CustomerOrderItems.Add(customerOrderItemVm); 
            }

            return Json(customerOrderVm);


        }
    }
}
