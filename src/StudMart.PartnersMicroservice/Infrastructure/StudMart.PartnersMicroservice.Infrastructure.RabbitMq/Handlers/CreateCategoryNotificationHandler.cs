using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Category;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Handlers.Base;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Helpers;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Handlers;

public class CreateCategoryNotificationHandler(IOptions<RabbitSettings> options, IMapper mapper, ILogger<CreateCategoryNotificationHandler> logger)
    : NotificationHandlerBase<CategoryCreatedNotification, CategoryModel, CategoryServiceModel>(options, mapper,
        "AddCategory", logger);