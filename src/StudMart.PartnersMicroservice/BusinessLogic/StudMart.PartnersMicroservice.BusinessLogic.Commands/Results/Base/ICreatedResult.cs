using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

public interface ICreatedResult<out TModel> : IResult where TModel: class, IModel
{
    TModel CreatedModel { get; }
}