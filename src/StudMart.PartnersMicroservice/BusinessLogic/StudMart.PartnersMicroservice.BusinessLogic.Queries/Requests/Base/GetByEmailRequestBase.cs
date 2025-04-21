using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;

public class GetByEmailRequestBase<TModel>(string email) : IGetByEmailRequest<TModel> where TModel: class?, IModel?
{
    public string Email => email;
}