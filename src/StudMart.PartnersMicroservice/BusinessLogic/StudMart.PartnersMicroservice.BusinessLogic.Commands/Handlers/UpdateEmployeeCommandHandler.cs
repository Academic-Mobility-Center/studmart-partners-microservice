using System.Text.Json;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class UpdateEmployeeCommandHandler(
    IEmployeesRepository employeesRepository,
    IPartnersRepository partnersRepository,
    IMapper mapper,
    ILogger<UpdateEmployeeCommandHandler> logger) : IRequestHandler<UpdateEmployeeCommand, IResult>
{
    public async Task<IResult> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation(JsonSerializer.Serialize(request));
        var verification = await employeesRepository.GetByIdAsync(request.Model.Id, cancellationToken);
        if (verification is null)
        {
            logger.LogWarning("Employee with id {ModelId} not found", request.Model.Id);
            return new EmployeeNotFoundResult(request.Model.Id);
        }

        verification = await employeesRepository.GetByEmailAsync(new Email(request.Model.Email), cancellationToken);
        if (verification is not null && verification.Id != request.Model.Id)
        {
            logger.LogWarning("Employee with id {ModelEmail} already exists", request.Model.Email);
            return new EmailAlreadyRegisteredResult(request.Model.Email);
        }

        var partner = await partnersRepository.GetByIdAsync(request.Model.PartnerId, cancellationToken);
        if (partner is null)
        {
            logger.LogWarning("Employee with id {ModelPartnerId} not found", request.Model.PartnerId);
            return new PartnerNotFoundResult(request.Model.PartnerId);
        }

        var employee = await employeesRepository.GetByIdAsync(request.Model.Id, cancellationToken);

        employee!.FirstName = new FirstName(request.Model.FirstName);
        employee.LastName = new LastName(request.Model.LastName);
        employee.Email = new Email(request.Model.Email);
        
        var result = await employeesRepository.UpdateAsync(employee, cancellationToken);
        if (result)
        {
            logger.LogInformation("Employee with id {ModelId} was updated", request.Model.Id);
            return new EmployeeUpdatedResult(mapper.Map<EmployeeModel>(employee));
        }
        logger.LogError("Error while updating employee with Id {ModelId}", request.Model.Id);
        return new InternalErrorResult();
    }
}