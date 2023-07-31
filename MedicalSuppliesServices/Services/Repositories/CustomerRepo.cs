using Microsoft.EntityFrameworkCore;
using MedicalSuppliesModels;
using MedicalSuppliesModels.Context;
using MedicalSuppliesServices.Services.Contracts;

namespace MedicalSuppliesServices.Services.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly MSDBContext _context;
        public CustomerRepo(MSDBContext context)
        {
            _context = context;
        }

        public void AddCustomer(Customer customer)
        {
            
            //IMPORTANT : need to do server side validation here
            
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void AddCustomerAddress(CustomerAddress address)
        {
            //IMPORTANT : need to do server side validation here

            _context.CustomerAddresses.Add(address);
            _context.SaveChanges();
        }

        public void AddCustomerInsurance(Insurance insurance)
        {

            //IMPORTANT : need to do server side validation here

            _context.Insurances.Add(insurance);
            _context.SaveChanges();
        }

        public void AddCustomerNumber(CustomerNumber number)
        {

            //IMPORTANT : need to do server side validation here

            _context.CustomerNumbers.Add(number);
            _context.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            var customers = _context.Customers
        .Include(c => c.Gender)
        .Include(c => c.CustomerAddresses)
            .ThenInclude(a => a.State) 
        .Include(c => c.CustomerNumbers)
        .Include(c => c.Insurances)
            .ThenInclude(i => i.InsuranceType)
        .ToList();

            return customers;
        }

        

        public int GetStateIdByName(string state)
        {
            //IMPORTANT : need to do server side validation here
            //make sure to do client side validation too

            var selectedState = _context.States.FirstOrDefault(p => p.LongState == state);
            if (selectedState != null)
            {
                return selectedState.StateId;
            }
            return -1;
        }

        public Customer GetCustomerById(int customerId)
        {
            var customer = _context.Customers
            .Include(g => g.Gender)
            .Include(c => c.CustomerAddresses)
            .ThenInclude(a => a.State)
            .Include(c => c.CustomerNumbers)   
            .Include(c => c.Insurances)
            .ThenInclude(i => i.InsuranceType)
            .FirstOrDefault(c => c.CustomerId == customerId);

            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            
            var existingCustomer = _context.Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);

            if (existingCustomer != null)
            {
                
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.DOB = customer.DOB;
                existingCustomer.Height = customer.Height;
                existingCustomer.Weight = customer.Weight;
                existingCustomer.Gender = customer.Gender;


                foreach (var address in customer.CustomerAddresses)
                {
                    var existingAddress = existingCustomer.CustomerAddresses
                        .FirstOrDefault(a => a.AddressId == address.AddressId);

                    if (existingAddress != null)
                    {
                        existingAddress.Address = address.Address;
                        existingAddress.City = address.City;
                        existingAddress.State = address.State;
                        existingAddress.Zip = address.Zip;
                    }
                    else
                    {                        
                        existingCustomer.CustomerAddresses.Add(address);
                    }
                }

                
                foreach (var number in customer.CustomerNumbers)
                {
                    var existingNumber = existingCustomer.CustomerNumbers
                        .FirstOrDefault(n => n.CustomerNumberId == number.CustomerNumberId);

                    if (existingNumber != null)
                    {
                        existingNumber.PhoneNumber = number.PhoneNumber;
                    }
                    else
                    {                        
                        existingCustomer.CustomerNumbers.Add(number);
                    }
                }

               
                foreach (var insurance in customer.Insurances)
                {
                    var existingInsurance = existingCustomer.Insurances
                        .FirstOrDefault(i => i.InsuranceId == insurance.InsuranceId);

                    if (existingInsurance != null)
                    {
                        existingInsurance.PolicyNo = insurance.PolicyNo;
                        existingInsurance.DateEffective = insurance.DateEffective;
                        existingInsurance.DateExpire = insurance.DateExpire;
                        existingInsurance.InsuranceType = insurance.InsuranceType;
                    }
                    else
                    {                        
                        existingCustomer.Insurances.Add(insurance);
                    }
                }

                _context.SaveChanges();
            }
        }
        //public void UpdateCustomerDetails(CustomerProfileVm viewModel)
        //{
        //    var customer = _context.Customers
        //        .Include(c => c.Gender)
        //        .Include(c => c.CustomerAddresses)
        //        .Include(c => c.CustomerNumbers)
        //        .Include(c => c.Insurances)
        //        .FirstOrDefault(c => c.CustomerId == viewModel.CustomerId);

        //    if (customer == null)
        //        throw new ArgumentException("Customer not found");


        //    customer.FirstName = viewModel.FirstName;
        //    customer.LastName = viewModel.LastName;
        //    customer.DOB = viewModel.DOB;
        //    customer.Height = viewModel.Height;
        //    customer.Weight = viewModel.Weight;
        //    customer.Gender = new Gender
        //    {
        //        GenderId = viewModel.Gender.GenderId,
        //        GenderName = viewModel.Gender.GenderName
        //    };



        //    _context.SaveChanges();
        //}
    }
}
