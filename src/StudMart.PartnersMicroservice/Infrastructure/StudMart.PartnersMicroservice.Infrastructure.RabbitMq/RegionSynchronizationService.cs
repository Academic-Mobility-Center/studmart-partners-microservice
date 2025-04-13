using AutoMapper;
using Microsoft.Extensions.Options;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Base;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Helpers;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq;

public class RegionSynchronizationService(IOptions<RabbitSettings> options, IMapper mapper)
    : SynchronizationServiceBase<RegionModel, RegionServiceModel>(options, mapper, "AddRegion");