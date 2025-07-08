using MediatR;
using Microsoft.Extensions.Logging;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Employee;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class DeleteEmployeeCommandHandler(
    IEmployeesRepository employeesRepository,
    ILogger<DeleteEmployeeCommandHandler> logger) : IRequestHandler<DeleteEmployeeCommand,  IResult>
{
    public async Task<IResult> Handle(DeleteEmployeeCommand  request, CancellationToken cancellationToken)
    {
        var employee = await employeesRepository.GetByIdAsync(request.Id, cancellationToken);

        if (employee == null)
        {
            logger.LogError($"Employee with id {request.Id} was not found");
            return new EmployeeNotFoundResult(request.Id);
        }
        
        var result = await employeesRepository.DeleteAsync(employee, cancellationToken);
        return result ? new EmployeeDeletedResult() : new InternalErrorResult();
    }
}