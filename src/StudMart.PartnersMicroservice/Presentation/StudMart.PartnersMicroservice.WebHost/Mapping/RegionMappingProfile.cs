using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;
using StudMart.PartnersMicroservice.WebHost.Requests.Region;
using StudMart.PartnersMicroservice.WebHost.Responses.Region;

namespace StudMart.PartnersMicroservice.WebHost.Mapping;

public class RegionMappingProfile : Profile
{
    public RegionMappingProfile()
    {
        CreateMap<RegionAddRequest, RegionAddModel>().ForCtorParam("Name", n => n.MapFrom(m => m.Name))
            .ForCtorParam("CountryId", expression => expression.MapFrom(request => request.CountyId));
        CreateMap<RegionModel, RegionResponse>();
        CreateMap<RegionModel, RegionShortResponse>();
    }
}