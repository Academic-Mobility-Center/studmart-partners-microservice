using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.Domain.Entities.Aggregates;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.BusinessLogic.Mapping;

public class PartnerMappingProfile : Profile
{
    public PartnerMappingProfile()
    {
        CreateMap<PaymentInformationModel, PaymentInfoContract>();
        CreateMap<PartnerAddModel, PartnerFactoryContract>();
        CreateMap<PaymentInformation, PaymentInformationModel>().ReverseMap();
        CreateMap<Partner, PartnerModel>().ForCtorParam("Id", expression => expression.MapFrom(partner => partner.Id))
            .ForCtorParam("CompanyName", opt => opt.MapFrom(src => src.CompanyName.Name))
            .ForCtorParam("Site", opt => opt.MapFrom(src => src.Site))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.Email))
            .ForCtorParam("Phone", expression => expression.MapFrom(partner => partner.Phone.Value))
            .ForCtorParam("Inn", expression => expression.MapFrom(partner => partner.Inn.Value)).ForCtorParam("Country",
                expression => expression.MapFrom(partner => partner.Country));
        CreateMap<Partner, PartnerShortModel>()
            .ForCtorParam("Id", expression => expression.MapFrom(partner => partner.Id))
            .ForCtorParam("CompanyName", opt => opt.MapFrom(src => src.CompanyName.Name))
            .ForCtorParam("Site", opt => opt.MapFrom(src => src.Site))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.Email))
            .ForCtorParam("Phone", expression => expression.MapFrom(partner => partner.Phone.Value))
            .ForCtorParam("Inn", expression => expression.MapFrom(partner => partner.Inn.Value)).ForCtorParam("Country",
                expression => expression.MapFrom(partner => partner.Country));
    }
}