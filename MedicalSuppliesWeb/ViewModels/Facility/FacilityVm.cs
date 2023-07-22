using MedicalSuppliesWeb.ViewModels.Facility;

namespace MedicalSuppliesWeb.ViewModels.Facility
{
    public class FacilityVm
    {
        public FacilityVm()
        {
            FacilityAddresses = new List<FacilityAddressVm>();
            FacilityNumbers = new List<FacilityNumberVm>();
        }

        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public List<FacilityAddressVm> FacilityAddresses { get; set; }
        public List<FacilityNumberVm> FacilityNumbers { get; set; }
    }
}
