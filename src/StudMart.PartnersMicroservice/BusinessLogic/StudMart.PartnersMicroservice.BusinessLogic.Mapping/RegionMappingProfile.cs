using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;

namespace StudMart.PartnersMicroservice.BusinessLogic.Mapping;

public class RegionMappingProfile : Profile
{
    public RegionMappingProfile()
    {
        CreateMap<RegionAddModel, RegionFactoryContract>();
        CreateMap<Region, RegionModel>().ReverseMap().ForMember(region => region.Name, opt => opt.MapFrom(regionModel => regionModel.Name));
    }
}