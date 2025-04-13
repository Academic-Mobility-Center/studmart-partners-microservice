using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Mapping;

public class PartnerMappingProfile : Profile
{
    public PartnerMappingProfile()
    {
        CreateMap<PartnerModel, PartnerServiceModel>();
    }
}