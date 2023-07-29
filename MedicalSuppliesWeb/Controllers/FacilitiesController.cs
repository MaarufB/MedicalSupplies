using MedicalSuppliesModels;
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


        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new FacilityVm();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(FacilityVm viewModel)
        {
            if (!ModelState.IsValid)
            {
                
                return View(viewModel);
            }

            
            var newFacilityEntity = new Facility
            {
                FacilityName = viewModel.FacilityName,
                ContactName = viewModel.ContactName,
                ContactEmail = viewModel.ContactEmail
            };

            
            foreach (var address in viewModel.FacilityAddresses)
            {
                newFacilityEntity.FacilityAddresses.Add(new FacilityAddress
                {
                    Address = address.Address,
                    City = address.City,
                    StateId = address.StateId, 
                    CountryId = address.Country.Id, 
                    Zip = address.Zip
                });
            }

            
            foreach (var number in viewModel.FacilityNumbers)
            {
                newFacilityEntity.FacilityNumbers.Add(new FacilityNumber
                {
                    PhoneNumber = number.PhoneNumber
                });
            }

            // Save the new Facility entity to the database
            //_facilityRepo.AddFacility(newFacilityEntity);
            //_facilityRepo.SaveChanges();

            // Redirect to the Details page for the newly created Facility or any other appropriate action
            return RedirectToAction("Details", new { id = newFacilityEntity.FacilityId });
        }
    }
}
