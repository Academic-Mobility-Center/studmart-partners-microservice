using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Handlers.Base;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Helpers;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Handlers;

public class DeleteEmployeeNotificationHandler(
    IOptions<RabbitSettings> options,
    IMapper mapper,
    ILogger<DeleteEmployeeNotificationHandler> logger) : NotificationHandlerBase<EmployeeDeletedNotification, EmployeeModel, EmployeeServiceModel>(options, mapper, "DeleteEmployee", logger)
{
    
}