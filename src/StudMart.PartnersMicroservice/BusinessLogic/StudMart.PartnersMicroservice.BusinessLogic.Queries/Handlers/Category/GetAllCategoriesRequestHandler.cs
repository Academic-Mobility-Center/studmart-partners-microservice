using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Category;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Category;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Category;

public class GetAllCategoriesRequestHandler(ICategoriesRepository repository, IMapper mapper)
    : GetAllRequestHandlerBase<GetAllCategoriesRequest, int, CategoryModel, Domain.Entities.Category>(repository,
        mapper)
{
}