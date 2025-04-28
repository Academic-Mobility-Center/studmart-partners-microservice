using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;

public class EmployeeUpdatedNotification(EmployeeModel model) : NotificationBase<EmployeeModel>(model)
{
    
}