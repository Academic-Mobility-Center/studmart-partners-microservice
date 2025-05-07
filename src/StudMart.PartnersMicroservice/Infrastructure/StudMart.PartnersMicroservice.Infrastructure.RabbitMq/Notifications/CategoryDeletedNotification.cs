using StudMart.PartnersMicroservice.BusinessLogic.Models.Category;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;

public class CategoryDeletedNotification(CategoryModel model) : NotificationBase<CategoryModel>(model)
{
    
}