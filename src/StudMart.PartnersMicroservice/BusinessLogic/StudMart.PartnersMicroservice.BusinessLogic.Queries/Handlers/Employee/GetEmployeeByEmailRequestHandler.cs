using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Employee;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Employee;

public class GetEmployeeByEmailRequestHandler(IEmployeesRepository repository, IMapper mapper)
    : GetByEmailRequestHandlerBase<GetEmployeeByEmailRequest, EmployeeModel, Domain.Entities.Employee, Guid>(repository,
        mapper);