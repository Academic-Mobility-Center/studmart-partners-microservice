using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Country;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Country;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Mapping;

public class CountryMappingProfile : Profile
{
    public CountryMappingProfile()
    {
        CreateMap<CountryAddRequest, CountryAddModel>();
        CreateMap<CountryModel, CountryResponse>();
        CreateMap<CountryShortModel, CountryShortResponse>();
        CreateMap<CountryModel, CountryShortResponse>();
    }
}