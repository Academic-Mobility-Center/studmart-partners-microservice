using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.WebHost.Requests.Employee;
using StudMart.PartnersMicroservice.WebHost.Responses.Employee;

namespace StudMart.PartnersMicroservice.WebHost.Mapping;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<EmployeeAddRequest, EmployeeAddModel>();
        CreateMap<EmployeeModel, EmployeeShortResponse>();
        CreateMap<EmployeeModel, EmployeeResponse>();
    }
}