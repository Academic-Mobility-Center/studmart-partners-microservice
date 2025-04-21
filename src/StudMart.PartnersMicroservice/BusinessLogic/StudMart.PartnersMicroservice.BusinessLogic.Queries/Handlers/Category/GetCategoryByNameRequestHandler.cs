using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Category;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Category;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Category;

public class GetCategoryByNameRequestHandler(ICategoriesRepository repository, IMapper mapper)
    : GetByNameRequestHandlerBase<GetCategoryByNameRequest, CategoryModel, Domain.Entities.Category, int, CategoryName>(
        repository, mapper);