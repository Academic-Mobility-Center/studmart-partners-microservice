using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.DescriptionRequest;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Mapping;

public class DescriptionRequestMappingProfile : Profile
{
    public DescriptionRequestMappingProfile()
    {
        CreateMap<DescriptionRequestModel, DescriptionRequestServiceModel>();
        CreateMap<DescriptionRequestRejectedModel, DescriptionRequestRejectedServiceModel>();
        CreateMap<DescriptionRequestAcceptedModel, DescriptionRequestAcceptedServiceModel>();
    }
}