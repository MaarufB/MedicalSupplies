using MedicalSuppliesServices.Services.Contracts;
using MedicalSuppliesWeb.ViewModels.Country;
using MedicalSuppliesWeb.ViewModels.Facility;
using MedicalSuppliesWeb.ViewModels.State;
using Microsoft.AspNetCore.Mvc;


namespace MedicalSuppliesWeb.Controllers
{
    public class FacilitiesController : Controller
    {
        private readonly IFacilityRepo _facilityRepo;
        public FacilitiesController(IFacilityRepo facilityRepo)
        {
            _facilityRepo = facilityRepo;
        }
        public IActionResult Index()
        {
            var facilities = _facilityRepo.GetAllFacilities();

            var facilityViewModel = facilities.Select(f => new FacilityVm
            {
                FacilityId = f.FacilityId,
                FacilityName = f.FacilityName,
                ContactName = f.ContactName,
                ContactEmail = f.ContactEmail,
                FacilityAddresses = f.FacilityAddresses.Select(a => new FacilityAddressVm
                {
                    Address = a.Address,
                    City = a.City,
                    Zip = a.Zip,
                    State = new StateVm
                    {
                        State = a.State.LongState
                    },
                    Country = new CountryVm
                    {
                        Country = a.Country.CountryName
                    }
                }).ToList(),
                FacilityNumbers = f.FacilityNumbers.Select(n => new FacilityNumberVm
                {
                    PhoneNumber = n.PhoneNumber
                }).ToList()
            }).ToList();

            return View(facilityViewModel);
        }
    }
}
