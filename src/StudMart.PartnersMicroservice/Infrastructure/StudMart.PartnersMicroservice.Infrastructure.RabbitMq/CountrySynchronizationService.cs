using AutoMapper;
using Microsoft.Extensions.Options;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Base;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Helpers;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq;

public class CountrySynchronizationService : SynchronizationServiceBase<CountryModel, CountryServiceModel>
{
    public CountrySynchronizationService(IOptions<RabbitSettings> options, IMapper mapper) : base(options, mapper, "AddCountry")
    {
    }
}