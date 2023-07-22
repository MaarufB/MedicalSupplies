using MedicalSuppliesModels;

namespace MedicalSuppliesServices.Services.Contracts
{
    public interface IFacilityRepo
    {
        public List<Facility> GetAllFacilities();
    }
}
