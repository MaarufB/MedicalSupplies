using UserRolesModels;
using UserRolesNew.ViewModels.Facility;

namespace UserRolesNew.Services.Contracts
{
    public interface IGooglePlacesService
    {
        Task<FacilityVm> GetFacilityDetails(Facility facility);
    }
}
