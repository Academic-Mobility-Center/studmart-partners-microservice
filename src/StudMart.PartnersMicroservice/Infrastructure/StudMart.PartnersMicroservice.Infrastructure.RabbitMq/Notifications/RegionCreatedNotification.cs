using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;

public class RegionCreatedNotification(RegionModel model) : NotificationBase<RegionModel>(model)
{
    
}