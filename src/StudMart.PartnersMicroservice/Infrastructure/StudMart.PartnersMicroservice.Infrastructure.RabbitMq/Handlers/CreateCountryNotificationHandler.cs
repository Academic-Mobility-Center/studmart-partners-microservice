using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Handlers.Base;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Helpers;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Handlers;


public class CreateCountryNotificationHandler(IOptions<RabbitSettings> options, IMapper mapper, ILogger<CreateCountryNotificationHandler> logger)
    : NotificationHandlerBase<CountryCreatedNotification, CountryModel, CountryServiceModel>(options, mapper,
        "AddCountry", logger);