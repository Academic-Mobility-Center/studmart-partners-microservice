using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Models.DescriptionRequest;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;

namespace StudMart.PartnersMicroservice.BusinessLogic.Mapping;

public class DescriptionRequestMappingProfile : Profile
{
    public DescriptionRequestMappingProfile()
    {
        CreateMap<DescriptionRequest, DescriptionRequestModel>()
            .ForCtorParam("Id", expression => expression.MapFrom(model => model.Id))
            .ForCtorParam("Description", expression => expression.MapFrom(model => model.Description.Value));
        CreateMap<DescriptionRequestAddModel, DescriptionRequestFactoryContract>();
    }
}