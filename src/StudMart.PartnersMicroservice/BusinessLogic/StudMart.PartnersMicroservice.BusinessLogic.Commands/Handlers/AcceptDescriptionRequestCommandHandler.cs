using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.DescriptionRequest;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class AcceptDescriptionRequestCommandHandler(
    IDescriptionRequestsRepository descriptionRequestsRepository,
    IPartnersRepository partnersRepository,
    IMapper mapper,
    ILogger<AcceptDescriptionRequestCommandHandler> logger) : IRequestHandler<AcceptDescriptionRequestCommand, IResult>
{
    public async Task<IResult> Handle(AcceptDescriptionRequestCommand request, CancellationToken cancellationToken)
    {
        var description = await descriptionRequestsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (description is null)
        {
            logger.LogWarning("Description request with id {RequestId} was not found", request.Id);
            return new DescriptionRequestNotFoundResult(request.Id);
        }

        var partner = description.Employee.Partner;
        var res = description.Accept();
        if (!res)
        {
            logger.LogError("Error while accepting description with Id {RequestId}", request.Id);
            return new InternalErrorResult();
        }

        res = await descriptionRequestsRepository.UpdateAsync(description, cancellationToken);
        if (!res)
            return new InternalErrorResult();
        partner.Description = description.Description;
        res = await partnersRepository.UpdateAsync(partner, cancellationToken);
        return res
            ? new DescriptionRequestAcceptedResult(mapper.Map<EmployeeModel>(description.Employee),
                mapper.Map<PartnerModel>(description.Employee.Partner))
            : new InternalErrorResult();
    }
}