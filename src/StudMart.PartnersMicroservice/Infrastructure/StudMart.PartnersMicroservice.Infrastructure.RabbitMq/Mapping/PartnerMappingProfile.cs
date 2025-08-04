using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Mapping;

public class PartnerMappingProfile : Profile
{
    public PartnerMappingProfile()
    {
        CreateMap<PartnerModel, PartnerServiceModel>()
            .ForCtorParam("CategoryId", expression => expression.MapFrom(model => model.Category.Id))
            .ForCtorParam("Id", expression => expression.MapFrom(model => model.Id))
            .ForCtorParam("CompanyName", expression => expression.MapFrom(model => model.Name))
            .ForCtorParam("HasAllRegions", expression => expression.MapFrom(model => model.HasAllRegions))
            .ForCtorParam("RegionIds", expression => expression.MapFrom(model => model.Regions.Select(region => region.Id)));
        CreateMap<PartnerShortModel, PartnerServiceModel>()
            .ForCtorParam("CategoryId", expression => expression.MapFrom(model => model.Category.Id))
            .ForCtorParam("Id", expression => expression.MapFrom(model => model.Id))
            .ForCtorParam("CompanyName", expression => expression.MapFrom(model => model.Name))
            .ForCtorParam("HasAllRegions", expression => expression.MapFrom(model => model.HasAllRegions))
            .ForCtorParam("RegionIds", expression => expression.MapFrom(model => model.Regions.Select(region => region.Id)));
        CreateMap<PartnerDeleteModel, PartnerDeletionServiceModel>()
            .ForCtorParam("PartnerId", expression => expression.MapFrom(model => model.PartnerId))
            .ForCtorParam("EmployeesIds", expression => expression.MapFrom(model => model.EmployeesIds));
    }
}