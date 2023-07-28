using MedicalSuppliesModels;
using MedicalSuppliesModels.Context;
using MedicalSuppliesServices.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MedicalSuppliesServices.Services.Repositories
{
    public class SupplierRepo : ISupplierRepo
    {
        private readonly MSDBContext _context;

        public SupplierRepo(MSDBContext context)
        {
            _context = context;
        }
        public List<Supplier> GetAllSuppliers()
        {
            var suppliers = _context.Suppliers
        .Include(s => s.SupplierAddresses) // Include addresses for each supplier.
            .ThenInclude(a => a.State)
        .Include(s => s.SupplierAddresses)// Include state for each address.
            .ThenInclude(a => a.Country) // Include country for each address.
        .Include(s => s.SupplierNumbers) // Include numbers for each supplier.
        .ToList();

            return suppliers;
        }

        public Supplier GetSupplierById(int supplierId)
        {
           var supplier =  _context.Suppliers.FirstOrDefault(s=>s.SupplierId == supplierId);
            return supplier;
        }
    }
}
