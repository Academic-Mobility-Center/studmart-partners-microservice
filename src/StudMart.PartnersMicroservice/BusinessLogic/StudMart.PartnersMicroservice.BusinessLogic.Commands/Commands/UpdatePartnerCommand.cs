using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;

public class UpdatePartnerCommand(UpdatePartnerModel model) : IRequest<IResult>
{
    public UpdatePartnerModel Model => model;
}