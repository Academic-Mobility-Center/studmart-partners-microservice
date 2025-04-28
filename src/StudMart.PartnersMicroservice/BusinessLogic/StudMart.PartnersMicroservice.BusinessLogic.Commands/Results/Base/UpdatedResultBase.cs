using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

public class UpdatedResultBase<TModel>(TModel model) : IUpdatedResult<TModel> where TModel : class, IModel
{
    public TModel Model =>  model;
}