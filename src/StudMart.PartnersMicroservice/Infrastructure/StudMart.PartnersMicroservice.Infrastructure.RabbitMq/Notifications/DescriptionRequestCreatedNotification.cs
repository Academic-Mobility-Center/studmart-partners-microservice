using StudMart.PartnersMicroservice.BusinessLogic.Models.DescriptionRequest;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;

public class DescriptionRequestCreatedNotification(DescriptionRequestModel model) : NotificationBase<DescriptionRequestModel>(model)
{
    
}