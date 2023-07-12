using Microsoft.EntityFrameworkCore;
using UserRolesData.Context;
using UserRolesModels;
using UserRolesNew.Services.Contracts;

namespace UserRolesNew.Services.Repositories
{
    public class SupplierOrderRepo : ISupplierOrderRepo
    {
        private readonly MSDBContext _context;

        public SupplierOrderRepo(MSDBContext context)
        {
            _context = context;
        }
        public List<SupplierOrder> GetAllSupplierOrders()
        {
            var supplierOrders = _context.SupplierOrders
                .Include(s => s.Supplier)
                .Include(p => p.PaymentMethod)
                .Include(t => t.TicketStatus)
                .ToList();

            return supplierOrders;
        }
    }
}
