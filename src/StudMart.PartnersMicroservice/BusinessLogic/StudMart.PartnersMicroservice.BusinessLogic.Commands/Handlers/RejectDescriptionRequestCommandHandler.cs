using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.DescriptionRequest;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class RejectDescriptionRequestCommandHandler(
    IDescriptionRequestsRepository descriptionRequestsRepository,
    IMapper mapper,
    ILogger<RejectDescriptionRequestCommandHandler> logger) : IRequestHandler<RejectDescriptionRequestCommand, IResult>
{
    public async Task<IResult> Handle(RejectDescriptionRequestCommand request, CancellationToken cancellationToken)
    {
        var description = await descriptionRequestsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (description is null)
        {
            logger.LogWarning("Description request with id {RequestId} was not found", request.Id);
            return new DescriptionRequestNotFoundResult(request.Id);
        }

        var partner = description.Employee.Partner;
        var res = description.Reject();
        if (!res)
        {
            logger.LogError("Error while accepting description with Id {RequestId}", request.Id);
            return new InternalErrorResult();
        }
        res = await descriptionRequestsRepository.UpdateAsync(description, cancellationToken);
        return res
            ? new DescriptionRequestRejectedResult(mapper.Map<EmployeeModel>(description.Employee))
            : new InternalErrorResult();
    }
}