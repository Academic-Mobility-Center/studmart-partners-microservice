using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;

namespace StudMart.PartnersMicroservice.BusinessLogic.Mapping;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<EmployeeAddModel, EmployeeFactoryContract>();
        CreateMap<Employee, EmployeeModel>().ReverseMap().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(employee => employee.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(employee => employee.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(employee => employee.LastName, opt => opt.MapFrom(src => src.LastName));
        
    }
}