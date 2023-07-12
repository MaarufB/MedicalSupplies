using Microsoft.EntityFrameworkCore;
using UserRolesData.Context;
using UserRolesModels;
using UserRolesNew.Services.Contracts;

namespace UserRolesNew.Services.Repositories
{
    public class SupplierInvoiceRepo : ISupplierInvoiceRepo
    {
        private readonly MSDBContext _context;

        public SupplierInvoiceRepo(MSDBContext context)
        {
            _context = context;
        }
        public List<SupplierInvoice> GetAllSupplierInvoices()
        {
            var supplierInvoices = _context.SupplierInvoices
                .Include(p => p.PaymentStatus)
                .Include(s => s.SupplierOrder)
                .Include(t => t.TicketStatus)
                .ToList();

            return supplierInvoices;
        }
    }
}
