using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Partner;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Partner;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Mapping;

public class PartnerMappingProfile : Profile
{
    public PartnerMappingProfile()
    {
        CreateMap<PartnerPaymentInformationRequest, PaymentInformationModel>();
        CreateMap<PaymentInformationModel, PartnerPaymentInformationResponse>();
        CreateMap<PartnerAddRequest, CreatePartnerCommand>().ReverseMap();
        CreateMap<PartnerAddRequest, PartnerAddModel>()
            .ForCtorParam("Name", opt => opt.MapFrom(src => src.Name))
            .ForCtorParam("Description", opt => opt.MapFrom(src => src.Description))
            .ForCtorParam("CategoryId", expression => expression.MapFrom(request => request.CategoryId ))
            .ForCtorParam("Subtitle", opt => opt.MapFrom(src => src.Subtitle))
            .ForCtorParam("Priority", opt => opt.MapFrom(src => src.Priority))
            .ForCtorParam("Site", opt => opt.MapFrom(src => src.Site))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.Email))
            .ForCtorParam("Phone", expression => expression.MapFrom(request => request.Phone))
            .ForCtorParam("Inn", expression => expression.MapFrom(request => request.Inn))
            .ForCtorParam("CountryId",
                expression => expression.MapFrom(request => request.CountryId))
            .ForCtorParam("PaymentInformation",
                expression => expression.MapFrom(request => request.PaymentInformation))
            .ForCtorParam("HasAllRegions", expression => expression.MapFrom(request => request.HasAllRegions))
            .ForCtorParam("RegionIds", expression => expression.MapFrom(request => request.RegionIds));
        CreateMap<PartnerShortModel, PartnerShortResponse>();
        CreateMap<PartnerModel, PartnerResponse>();
        CreateMap<PartnerModel, PartnerShortResponse>();
        CreateMap<UpdatePartnerRequest, UpdatePartnerModel>()
            .ForCtorParam("Id",  opt => opt.MapFrom(request => request.Id))
            .ForCtorParam("Name", opt => opt.MapFrom(src => src.Name))
            .ForCtorParam("Description", opt => opt.MapFrom(src => src.Description))
            .ForCtorParam("CategoryId", expression => expression.MapFrom(request => request.CategoryId ))
            .ForCtorParam("Subtitle", opt => opt.MapFrom(src => src.Subtitle))
            .ForCtorParam("Priority", opt => opt.MapFrom(src => src.Priority))
            .ForCtorParam("Site", opt => opt.MapFrom(src => src.Site))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.Email))
            .ForCtorParam("Phone", expression => expression.MapFrom(request => request.Phone))
            .ForCtorParam("Inn", expression => expression.MapFrom(request => request.Inn))
            .ForCtorParam("CountryId",
                expression => expression.MapFrom(request => request.CountryId))
            .ForCtorParam("PaymentInformation",
                expression => expression.MapFrom(request => request.PaymentInformation))
            .ForCtorParam("HasAllRegions", expression => expression.MapFrom(request => request.HasAllRegions))
            .ForCtorParam("RegionIds", expression => expression.MapFrom(request => request.RegionIds));
        
    }
}