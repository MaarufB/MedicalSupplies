using Microsoft.EntityFrameworkCore;
using UserRolesData.Context;
using UserRolesModels;
using UserRolesNew.Services.Contracts;

namespace UserRolesNew.Services.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly MSDBContext _context;
        public CustomerRepo(MSDBContext context)
        {
            _context = context;
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
    }
}
