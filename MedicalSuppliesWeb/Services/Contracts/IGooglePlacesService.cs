using MedicalSuppliesModels;
using MedicalSuppliesWeb.ViewModels.Facility;


namespace MedicalSuppliesWeb.Services.Contracts
{
    public interface IGooglePlacesService
    {
        Task<FacilityVm> GetFacilityDetails(Facility facility);
    }
}
