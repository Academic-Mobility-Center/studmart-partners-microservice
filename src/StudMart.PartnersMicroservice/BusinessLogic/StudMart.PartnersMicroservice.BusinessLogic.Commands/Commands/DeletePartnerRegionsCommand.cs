using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;

public class DeletePartnerRegionsCommand(Guid partnerId) :  IRequest<IResult>
{
    public Guid PartnerId => partnerId;
}