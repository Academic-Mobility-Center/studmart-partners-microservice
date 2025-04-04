using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Category;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Category;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Category;

public class GetCategoryByIdRequestHandler(ICategoriesRepository repository, IMapper mapper)
    : GetByIdRequestHandlerBase<GetCategoryByIdRequest, CategoryModel, int, Domain.Entities.Category>(repository,
        mapper)
{
}