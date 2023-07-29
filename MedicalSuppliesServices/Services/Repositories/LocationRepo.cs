using MedicalSuppliesModels;
using MedicalSuppliesModels.Context;
using MedicalSuppliesServices.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesServices.Services.Repositories
{
    public class LocationRepo : ILocationRepo
    {
        private readonly MSDBContext _context;
        public LocationRepo(MSDBContext context)
        {
            _context = context;
        }
        public List<Location> GetAllLocations()
        {
            return (_context.Locations.ToList());
        }
    }
}
