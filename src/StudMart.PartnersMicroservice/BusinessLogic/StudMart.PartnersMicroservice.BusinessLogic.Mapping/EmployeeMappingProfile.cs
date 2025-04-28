using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;

namespace StudMart.PartnersMicroservice.BusinessLogic.Mapping;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<EmployeeAddModel, EmployeeFactoryContract>().ReverseMap()
            .ForCtorParam("FirstName", opt => opt.MapFrom(src => src.FirstName))
            .ForCtorParam("LastName", opt => opt.MapFrom(src => src.LastName))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.Email))
            .ForCtorParam("PartnerId", opt => opt.MapFrom(src => src.PartnerId));
        CreateMap<EmployeeFactoryContract, EmployeeAddModel>().ReverseMap()
            .ForCtorParam("FirstName", opt => opt.MapFrom(src => src.FirstName))
            .ForCtorParam("LastName", opt => opt.MapFrom(src => src.LastName))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.Email))
            .ForCtorParam("PartnerId", opt => opt.MapFrom(src => src.PartnerId));
        CreateMap<Employee, EmployeeModel>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("FirstName", opt => opt.MapFrom(src => src.FirstName))
            .ForCtorParam("LastName", opt => opt.MapFrom(src => src.LastName))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.Email))
            .ForCtorParam("Partner",  opt => opt.MapFrom(src => src.Partner));

    }
}