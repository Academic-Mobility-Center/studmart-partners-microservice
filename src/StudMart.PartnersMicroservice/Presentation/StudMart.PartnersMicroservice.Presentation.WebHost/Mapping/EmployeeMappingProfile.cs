using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Employee;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Employee;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Mapping;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<EmployeeAddRequest, EmployeeAddModel>();
        CreateMap<EmployeeModel, EmployeeShortResponse>();
        CreateMap<EmployeeModel, EmployeeResponse>();
        CreateMap<UpdateEmployeeRequest, UpdateEmployeeModel>();
    }
}