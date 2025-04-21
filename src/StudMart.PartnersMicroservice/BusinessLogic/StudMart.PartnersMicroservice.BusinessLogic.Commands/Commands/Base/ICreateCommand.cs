using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using MediatR;
public interface ICreateCommand<out TAddModel> : IRequest<IResult> where TAddModel: class, IAddModel
{
    TAddModel Model { get; }
}