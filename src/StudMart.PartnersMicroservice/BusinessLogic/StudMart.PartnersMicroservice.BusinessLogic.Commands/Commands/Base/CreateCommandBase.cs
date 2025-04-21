using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands.Base;

public abstract class CreateCommandBase<TAddModel>(TAddModel model)
    : ICreateCommand<TAddModel> where TAddModel : class, IAddModel
{
    public TAddModel Model { get; } = model;
}