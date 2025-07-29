using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Helpers;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class DeletePartnerRegionsCommandHandler(
    DataContext dataContext,
    ILogger<DeletePartnerRegionsCommandHandler> logger) : IRequestHandler<DeletePartnerRegionsCommand,  IResult>
{
    public async Task<IResult> Handle(DeletePartnerRegionsCommand request, CancellationToken cancellationToken)
    {
        var regionsDeleted = await dataContext.Database.ExecuteSqlRawAsync(
            CustomSQLQueryHelper.DeletePartnersRegionsQuery,
            [request.PartnerId],
            cancellationToken: cancellationToken);

        return regionsDeleted > 0
            ? new PartnerRegionsDeletedResult()
            : new PartnerRegionsNotFoundResult(request.PartnerId);
    }
}