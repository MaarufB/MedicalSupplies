using Microsoft.EntityFrameworkCore;
using MedicalSuppliesModels;
using MedicalSuppliesModels.Context;
using MedicalSuppliesServices.Services.Contracts;

namespace MedicalSuppliesServices.Services.Repositories
{
    public class FacilityRepo : IFacilityRepo
    {
        private readonly MSDBContext _context;
        public FacilityRepo(MSDBContext context)
        {
            _context = context;
        }
        public List<Facility> GetAllFacilities()
        {
            var facilities = _context.Facilities
                                .Include(f => f.FacilityAddresses)
                                    .ThenInclude(a => a.State)
                                .Include((f => f.FacilityAddresses))
                                    .ThenInclude(s => s.Country)
                                .Include(f => f.FacilityNumbers)
                                .ToList();

            return facilities;
        }
    }
}
