using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;

public interface IGetByNameRequest<out TModel> : IRequest<TModel?> where TModel : class?, IModel?
{
    string Name { get; }
}