using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.DescriptionRequest;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.DescriptionRequest;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.DiscountDescription;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Mapping;

public class DescriptionRequestMappingProfile : Profile
{
    public DescriptionRequestMappingProfile()
    {
        CreateMap<DescriptionRequestAddRequest, DescriptionRequestAddModel>();
        CreateMap<DescriptionRequestModel, DescriptionRequestResponse>();
    }
}