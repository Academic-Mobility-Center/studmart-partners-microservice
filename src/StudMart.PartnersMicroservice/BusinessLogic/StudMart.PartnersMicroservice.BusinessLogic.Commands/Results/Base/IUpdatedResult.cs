using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

public interface IUpdatedResult<out TModel> : ISuccessResult where TModel : class, IModel
{
    public TModel Model { get; }
}