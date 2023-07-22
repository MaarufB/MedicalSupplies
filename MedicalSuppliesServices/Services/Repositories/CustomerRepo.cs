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
    }
}
