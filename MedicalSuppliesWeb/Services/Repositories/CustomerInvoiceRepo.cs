using Microsoft.EntityFrameworkCore;
using MedicalSuppliesModels;
using MedicalSuppliesModels.Context;
using MedicalSuppliesWeb.Services.Contracts;

namespace MedicalSuppliesWeb.Services.Repositories
{
    public class CustomerInvoiceRepo : ICustomerInvoiceRepo
    {
        private readonly MSDBContext _context;

        public CustomerInvoiceRepo(MSDBContext context)
        {
            _context = context;
        }
        public List<CustomerInvoice> GetAllCustomerInvoices()
        {
            var customerInvoices = _context.CustomerInvoices
                .Include(c => c.CustomerOrder)
                .Include(p => p.PaymentStatus)
                .Include(t => t.TicketStatus)
                .Include(i => i.CustomerInvoiceItems)
                .Include(r => r.CustomerOrder.Customer)
                .ToList();

            return customerInvoices;
        }
    }
}
