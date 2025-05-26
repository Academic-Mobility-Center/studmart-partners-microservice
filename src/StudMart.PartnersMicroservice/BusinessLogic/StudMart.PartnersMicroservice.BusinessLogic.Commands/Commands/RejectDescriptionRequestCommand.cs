using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;

public class RejectDescriptionRequestCommand(Guid id) : IRequest<IResult>
{
    public Guid Id => id;
}