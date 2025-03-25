using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands.Base;

public abstract class CreateCommandBase<TModel, TAddModel>(TAddModel model)
    : ICreateCommand<TModel, TAddModel> where TModel : class, IModel where TAddModel : class, IAddModel
{
    public TAddModel Model { get; } = model;
}