using AutoMapper;
using Microsoft.Extensions.Options;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Handlers.Base;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Helpers;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Handlers;

public class RegionCreatedNotificationHandler(IOptions<RabbitSettings> options, IMapper mapper)
    : CreatedNotificationHandlerBase<RegionCreatedNotification, RegionModel, RegionServiceModel>(options, mapper,
        "AddRegion");