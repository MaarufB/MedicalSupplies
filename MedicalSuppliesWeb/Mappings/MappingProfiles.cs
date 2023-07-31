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

            
            CreateMap<InsuranceType, CustomerInsuranceTypeVm>()
                .ForMember(dest => dest.InsuranceTypeId, opt => opt.MapFrom(src => src.InsuranceTypeId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            
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

            
            CreateMap<CustomerNumber, CustomerNumberVm>()
                .ForMember(dest => dest.CustomerNumberId, opt => opt.MapFrom(src => src.CustomerNumberId))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));


            CreateMap<Customer, CustomerProfileVm>()

                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DOB, opt => opt.MapFrom(src => src.DOB))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.InsuranceDetails, opt => opt.MapFrom(src => src.Insurances.FirstOrDefault()))
                .ForMember(dest => dest.CustomerAddresses, opt => opt.MapFrom(src => src.CustomerAddresses))
                .ForMember(dest => dest.CustomerNumbers, opt => opt.MapFrom(src => src.CustomerNumbers))
                .ForMember(dest => dest.Insurances, opt => opt.MapFrom(src => src.Insurances));


                //.ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))









        }
    }
}
