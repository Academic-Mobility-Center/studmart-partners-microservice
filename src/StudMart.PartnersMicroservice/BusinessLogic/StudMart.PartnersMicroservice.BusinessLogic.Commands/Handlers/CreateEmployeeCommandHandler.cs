using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Repositories.Abstractions;
using SudMart.PartnersMicroservice.Domain.Factories.Implementations;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class CreateEmployeeCommandHandler(
    IEmployeesRepository repository,
    IEmployeeFactory factory,
    IMapper mapper)
    : CreateCommandHandlerBase<CreateEmployeeCommand, EmployeeModel, EmployeeAddModel, Employee, Guid, EmployeeFactory,
        EmployeeFactoryContract>(repository, factory, mapper)
{
}