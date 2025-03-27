using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Employee;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Employee;

public class GetEmployeeRequestHandler(IEmployeesRepository repository, IMapper mapper) : GetByIdRequestHandlerBase<GetEmployeeRequest, EmployeeModel, Guid, Domain.Entities.Employee>(repository, mapper)
{
    
}