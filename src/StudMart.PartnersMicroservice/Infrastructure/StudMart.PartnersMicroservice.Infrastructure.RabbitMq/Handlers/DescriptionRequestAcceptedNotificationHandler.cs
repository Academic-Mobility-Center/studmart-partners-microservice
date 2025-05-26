using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudMart.PartnersMicroservice.BusinessLogic.Models.DescriptionRequest;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Handlers.Base;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Helpers;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Handlers;

public class DescriptionRequestAcceptedNotificationHandler(
    IOptions<RabbitSettings> options,
    IMapper mapper,
    ILogger<DescriptionRequestAcceptedNotificationHandler> logger)
    : NotificationHandlerBase<DescriptionRequestAcceptedNotification, DescriptionRequestAcceptedModel,
        DescriptionRequestAcceptedServiceModel>(options, mapper, "DescriptionRequestAccepted", logger);