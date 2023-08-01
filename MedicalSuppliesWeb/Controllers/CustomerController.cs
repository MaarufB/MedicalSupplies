using Microsoft.AspNetCore.Mvc;
using MedicalSuppliesModels;
using MedicalSuppliesWeb.ViewModels.Customer;
using MedicalSuppliesWeb.ViewModels.State;
using MedicalSuppliesServices.Services.Contracts;
using AutoMapper;

namespace MedicalSuppliesWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly ICustomerOrderRepo _customerOrderRepo;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepo customerRepo, ICustomerOrderRepo customerOrderRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _customerOrderRepo = customerOrderRepo;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var customers = _customerRepo.GetAllCustomers();
            var customerProfiles = _mapper.Map<List<CustomerProfileVm>>(customers);
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

                var customer = _mapper.Map<Customer>(viewModel);
                    
                    
                //    new Customer
                //{
                //    FirstName = viewModel.FirstName,
                //    LastName = viewModel.LastName,
                //    DOB = viewModel.DOB,
                //    Height = viewModel.Height,
                //    Weight = viewModel.Weight,

                //    Gender = new Gender
                //    {
                //        GenderId = viewModel.Gender.GenderId,
                //        GenderName = viewModel.Gender.GenderName
                //    }

                //};

                //customer.GenderId = viewModel.Gender.GenderId;


                _customerRepo.AddCustomer(customer);
              

                //foreach (var addressVm in viewModel.CustomerAddresses)
                //{
                //    var stateId = _customerRepo.GetStateIdByName(addressVm.State.State);
                //    var address = new CustomerAddress
                //    {
                //        Address = addressVm.Address,
                //        City = addressVm.City,
                //        StateId = stateId, 
                //        Zip = addressVm.Zip,
                //        CustomerId = customer.CustomerId // this is needed to set the foreign key link to the customer table
                //    };

                //    _customerRepo.AddCustomerAddress(address);
                //}

                //foreach (var numberVm in viewModel.CustomerNumbers)
                //{
                //    var number = new CustomerNumber
                //    {
                //        PhoneNumber = numberVm.PhoneNumber,
                //        CustomerId = customer.CustomerId // for foreign key
                //    };
                //    _customerRepo.AddCustomerNumber(number);
                //}

                //foreach (var insuranceVm in viewModel.Insurances)
                //{
                //    var insurance = new Insurance
                //    {
                //        CustomerId = customer.CustomerId, // for foreign key
                //        InsuranceTypeId = insuranceVm.InsuranceTypeId,
                //        GroupId = insuranceVm.GroupId,
                //        PolicyNo = insuranceVm.PolicyNo,
                //        PrimaryInsurance = insuranceVm.PrimaryInsurance,
                //        SecondaryInsurance = insuranceVm.SecondaryInsurance,
                //        DateEffective = insuranceVm.DateEffective,
                //        DateExpire = insuranceVm.DateExpire
                //    };
                //    _customerRepo.AddCustomerInsurance(insurance);
                //}
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
                return RedirectToAction("OrderSubmitted");
            }

           
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
                return RedirectToAction("InvoiceSubmitted");
            }

            
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetCustomerDetails(int customerId)
        {
            var customer = _customerRepo.GetCustomerById(customerId);
            if (customer != null)
            {                
                return Json(new { firstName = customer.FirstName, lastName = customer.LastName });
            }

           
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


        public IActionResult Details(int id)
        {
            var customer = _customerRepo.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            var customerViewModel = _mapper.Map<CustomerProfileVm>(customer);

            return View(customerViewModel);
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = _customerRepo.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }            
            var customerViewModel = _mapper.Map<CustomerProfileVm>(customer);            
            return View(customerViewModel);
        }




        [HttpPost]
        public IActionResult Edit(CustomerProfileVm viewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = _customerRepo.GetCustomerById(viewModel.CustomerId);
                if (customer == null)
                {
                    return NotFound();
                }
               
                _mapper.Map(viewModel, customer);
                _customerRepo.UpdateCustomer(customer);

                return RedirectToAction("Details", new { id = viewModel.CustomerId });
            }

            return View(viewModel);
        }



    }
}
