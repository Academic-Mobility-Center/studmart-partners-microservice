using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Mapping;

public class RegionMappingProfile : Profile
{
    public RegionMappingProfile()
    {
        CreateMap<RegionModel, RegionServiceModel>()
            .ForCtorParam("CountryId", opt => opt.MapFrom(src => src.Country.Id));
    }
}