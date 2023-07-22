using MedicalSuppliesWeb.ViewModels.Country;
using MedicalSuppliesWeb.ViewModels.State;

namespace MedicalSuppliesWeb.ViewModels.Facility
{
    public class FacilityAddressVm
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public StateVm State { get; set; }
        public CountryVm Country { get; set; }
    }
}
