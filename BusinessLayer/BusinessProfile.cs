using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Models;

namespace BusinessLayer
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMapper();
        }

        private void CreateMapper()
        {
            CreateMap<DataEntity, BaseInfo>();
            CreateMap<Company, CompanyInfo>();
            CreateMap<CompanyInfo, Company>();
            CreateMap<Employee, EmployeeInfo>()
                .ForMember(dest => dest.CompanyName, act => act.MapFrom(src => src.CompanyCode)) // not sure
                .ForMember(dest => dest.OccupationName, act => act.MapFrom(src => src.Occupation))
                .ForMember(dest => dest.PhoneNumber, act => act.MapFrom(src => src.Phone))
                .ForMember(dest => dest.LastModifiedDateTime, act => act.MapFrom(src => src.LastModified.ToString()));
            CreateMap<ArSubledger, ArSubledgerInfo>();
        }
    }

}