using AutoMapper;
using MedicalSuppliesModels;
using MedicalSuppliesWeb.ViewModels.Customer;
using MedicalSuppliesWeb.ViewModels.State;

namespace MedicalSuppliesMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<Gender, CustomerGenderVm>().ReverseMap();

            CreateMap<State, StateVm>().ReverseMap();


            CreateMap<CustomerAddress, CustomerAddressVm>()
                .ForMember(dest => dest.CustomerAddressId, opt => opt.MapFrom(src => src.AddressId)).ReverseMap();
            

            
            CreateMap<InsuranceType, CustomerInsuranceTypeVm>().ReverseMap();

            
            CreateMap<Insurance, CustomerInsuranceVm>().ReverseMap();

            
            CreateMap<CustomerNumber, CustomerNumberVm>().ReverseMap();


            CreateMap<Customer, CustomerProfileVm>().ReverseMap();


                //.ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))









        }
    }
}
