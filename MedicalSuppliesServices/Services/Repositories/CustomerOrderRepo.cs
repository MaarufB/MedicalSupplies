using Microsoft.EntityFrameworkCore;
using MedicalSuppliesModels;
using MedicalSuppliesModels.Context;
using MedicalSuppliesServices.Services.Contracts;

namespace MedicalSuppliesServices.Services.Repositories
{
    public class CustomerOrderRepo : ICustomerOrderRepo
    {
        private readonly MSDBContext _context;

        public CustomerOrderRepo(MSDBContext context)
        {
            _context = context;
        }
        public List<CustomerOrder> GetAllCustomerOrders()
        {
            var customerOrders = _context.CustomerOrders
                .Include(t => t.TicketStatus)
                .Include(t => t.Customer)
                .Include(t => t.PaymentMethod)
                .Include(i => i.CustomerOrderItems)
                .ToList();
            return customerOrders;
        }

        public CustomerOrder GetCustomerOrderDetails(int customerOrderId)
        {
            var customerOrder = _context.CustomerOrders
         .Include(co => co.Customer)
         .Include(co => co.CustomerOrderItems)
             .ThenInclude(coi => coi.Product) 
         .FirstOrDefault(co => co.CustomerOrderId == customerOrderId);


            return customerOrder;
        }
    }
}
