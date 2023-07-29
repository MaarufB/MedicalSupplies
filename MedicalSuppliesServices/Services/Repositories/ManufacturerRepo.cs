using MedicalSuppliesModels;
using MedicalSuppliesModels.Context;
using MedicalSuppliesServices.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesServices.Services.Repositories
{
    public class ManufacturerRepo : IManufacturerRepo
    {
        private readonly MSDBContext _context;

        public ManufacturerRepo(MSDBContext context)
        {
            _context= context;
        }
        public List<Manufacturer> GetAllManufacturers()
        {
            var manufacturers = _context.Manufacturers
                .Include(s => s.ManufacturerAddresses) // Include addresses for each supplier.
            .ThenInclude(a => a.State)
        .Include(s => s.ManufacturerAddresses)// Include state for each address.
            .ThenInclude(a => a.Country) // Include country for each address.
        .Include(s => s.ManufacturerNumbers) // Include numbers for each supplier.
        .ToList();
            return manufacturers;
        }
    }
}
