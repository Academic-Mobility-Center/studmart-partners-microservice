using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Helpers;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class DeletePartnerEmployeesCommandHandler(
    DataContext dataContext,
    ILogger<DeletePartnerEmployeesCommandHandler> logger) : IRequestHandler<DeletePartnerEmployeesCommand,  IResult>
{
    public async Task<IResult> Handle(DeletePartnerEmployeesCommand request, CancellationToken cancellationToken)
    {
        var deleteEmployeeResult = await dataContext.Database.ExecuteSqlRawAsync(
            CustomSQLQueryHelper.DeletePartnerEmployeesByPartnerIdQuery, 
            [request.PartnerId],
            cancellationToken: cancellationToken);
        
        return  deleteEmployeeResult > 0 
                ? new PartnerEmployeesDeletedResult()
                : new PartnerEmployeesNotFoundResult(request.PartnerId);
    }
}