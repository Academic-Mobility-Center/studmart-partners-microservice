using MediatR;
using Microsoft.Extensions.Logging;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class DeletePartnerCommandHandler(
    IPartnersRepository partnersRepository,
    ILogger<DeletePartnerCommandHandler> logger) : IRequestHandler<DeletePartnerCommand,  IResult>
{
    public async Task<IResult> Handle(DeletePartnerCommand request, CancellationToken cancellationToken)
    {
        var partner = await partnersRepository.GetByIdAsync(request.Id);

        if (partner is null)
        {
            logger.LogError($"Partner with id {request.Id} was not found");
            return new PartnerNotFoundResult(request.Id);
        }

        var deleteResult = await partnersRepository.DeleteAsync(partner);

        return deleteResult ? new PartnerDeletedResult() : new InternalErrorResult();
    }
}