using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Category;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Category;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Category;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Mapping;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<CategoryAddRequest, CategoryAddModel>();
        CreateMap<CategoryModel, CategoryResponse>();
        CreateMap<UpdateCategoryRequest, UpdateCategoryModel>();
    }
}