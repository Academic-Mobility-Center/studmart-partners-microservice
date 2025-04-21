using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

public abstract class CreatedResultBase<TModel> : ICreatedResult<TModel>
    where TModel : class, IModel
{
    public TModel CreatedModel { get; init; }
}