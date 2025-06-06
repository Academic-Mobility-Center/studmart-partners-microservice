using AutoMapper;
using Microsoft.Extensions.Logging;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.ErrorResultsProcessors;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Repositories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class CreateEmployeeCommandHandler(
    IEmployeesRepository repository,
    IEmployeeFactory factory,
    IMapper mapper, ILogger<CreateEmployeeCommandHandler> logger)
    : CreateCommandHandlerBase<CreateEmployeeCommand, EmployeeModel, EmployeeAddModel, Employee, Guid, EmployeeFactory,
        EmployeeFactoryContract, EmployeeCreatedResult>(repository, factory, mapper, new EmployeeErrorsResultProcessor(), logger)
{
}