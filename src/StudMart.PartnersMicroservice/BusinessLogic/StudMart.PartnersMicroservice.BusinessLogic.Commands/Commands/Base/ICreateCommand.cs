namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using MediatR;
public interface ICreateCommand<out TModel, out TAddModel> : IRequest<TModel> where  TModel : IModel where TAddModel: class, IAddModel
{
    TAddModel Model { get; }
}