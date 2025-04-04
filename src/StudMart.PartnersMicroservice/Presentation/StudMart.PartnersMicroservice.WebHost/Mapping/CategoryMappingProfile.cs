using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Category;
using StudMart.PartnersMicroservice.WebHost.Requests.Category;
using StudMart.PartnersMicroservice.WebHost.Responses.Category;

namespace StudMart.PartnersMicroservice.WebHost.Mapping;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<CategoryAddRequest, CategoryAddModel>();
        CreateMap<CategoryModel, CategoryResponse>();
    }
}