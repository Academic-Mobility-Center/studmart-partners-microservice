using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudMart.PartnersMicroservice.BusinessLogic.Models.DescriptionRequest;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Handlers.Base;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Helpers;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Handlers;

public class DescriptionRequestRejectedNotificationHandler(
    IOptions<RabbitSettings> options,
    IMapper mapper,
    ILogger<DescriptionRequestRejectedNotificationHandler> logger)
    : NotificationHandlerBase<DescriptionRequestRejectedNotification, DescriptionRequestRejectedModel,
        DescriptionRequestRejectedServiceModel>(options, mapper, "DescriptionRequestRejected", logger);