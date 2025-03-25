using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;

namespace StudMart.PartnersMicroservice.BusinessLogic.Mapping;

public class CountryMappingProfile : Profile
{
    public CountryMappingProfile()
    {
        CreateMap<CountryAddModel, CountryFactoryContract>();
        CreateMap<Country, CountryModel>().ReverseMap().ForMember(country => country.Name, opt => opt.MapFrom(countryModel => countryModel.Name));
    }
    
}