using AutoMapper;
using MedicalSuppliesModels;

namespace MedicalSuppliesMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerProfileVm>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender)); // Mapping for the Gender property

            // Add other mappings here for Address, Insurance, and Number if needed
            CreateMap<CustomerAddress, CustomerAddressVm>();
            CreateMap<Insurance, CustomerInsuranceVm>();
            CreateMap<CustomerNumber, CustomerNumberVm>();
        }
    }
}