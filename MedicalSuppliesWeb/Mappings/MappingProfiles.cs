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
            // Mapping for the Gender property
            CreateMap<Gender, CustomerGenderVm>()
                .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.GenderId))
                .ForMember(dest => dest.GenderName, opt => opt.MapFrom(src => src.GenderName));

            CreateMap<State, StateVm>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StateId))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.LongState));

            CreateMap<CustomerAddress, CustomerAddressVm>()
                .ForMember(dest => dest.CustomerAddressId, opt => opt.MapFrom(src => src.AddressId))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.Zip, opt => opt.MapFrom(src => src.Zip));

            // Mapping for the InsuranceType property
            CreateMap<InsuranceType, CustomerInsuranceTypeVm>()
                .ForMember(dest => dest.InsuranceTypeId, opt => opt.MapFrom(src => src.InsuranceTypeId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            // Mapping for the Insurance property
            CreateMap<Insurance, CustomerInsuranceVm>()
                .ForMember(dest => dest.InsuranceId, opt => opt.MapFrom(src => src.InsuranceId))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.InsuranceTypeId, opt => opt.MapFrom(src => src.InsuranceTypeId))
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId))
                .ForMember(dest => dest.PolicyNo, opt => opt.MapFrom(src => src.PolicyNo))
                .ForMember(dest => dest.PrimaryInsurance, opt => opt.MapFrom(src => src.PrimaryInsurance))
                .ForMember(dest => dest.SecondaryInsurance, opt => opt.MapFrom(src => src.SecondaryInsurance))
                .ForMember(dest => dest.DateEffective, opt => opt.MapFrom(src => src.DateEffective))
                .ForMember(dest => dest.DateExpire, opt => opt.MapFrom(src => src.DateExpire))
                .ForMember(dest => dest.InsuranceType, opt => opt.MapFrom(src => src.InsuranceType));

            // Mapping for the CustomerNumber property
            CreateMap<CustomerNumber, CustomerNumberVm>()
                .ForMember(dest => dest.CustomerNumberId, opt => opt.MapFrom(src => src.CustomerNumberId))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));

            // Mapping for the CustomerAddresses collection
            CreateMap<Customer, CustomerProfileVm>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender)) // Map Gender property
                .ForMember(dest => dest.InsuranceDetails, opt => opt.MapFrom(src => src.Insurances.FirstOrDefault())) // Map first Insurance to InsuranceDetails
                .ForMember(dest => dest.CustomerAddresses, opt => opt.MapFrom(src => src.CustomerAddresses)) // Map CustomerAddresses collection
                .ForMember(dest => dest.CustomerNumbers, opt => opt.MapFrom(src => src.CustomerNumbers)) // Map CustomerNumbers collection
                .ForMember(dest => dest.Insurances, opt => opt.MapFrom(src => src.Insurances)); // Map Insurances collection
        }
    }
}
