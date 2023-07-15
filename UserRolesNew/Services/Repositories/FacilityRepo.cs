using Microsoft.EntityFrameworkCore;
using UserRolesData.Context;
using UserRolesModels;
using UserRolesNew.Services.Contracts;

namespace UserRolesNew.Services.Repositories
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
