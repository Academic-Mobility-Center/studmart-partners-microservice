using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Handlers.Base;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Helpers;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Handlers;

public class CreatePartnerNotificationHandler(IOptions<RabbitSettings> options, IMapper mapper, ILogger<CreatePartnerNotificationHandler> logger)
    : NotificationHandlerBase<PartnerCreatedNotification, PartnerModel, PartnerServiceModel>(options, mapper,
        "AddPartner", logger);