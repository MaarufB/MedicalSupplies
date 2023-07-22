using Microsoft.EntityFrameworkCore;
using MedicalSuppliesModels;
using UserRolesNew.Services.Contracts;
using MedicalSuppliesModels.Context;

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
