using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;

public class CountryCreatedNotification(CountryModel model) : NotificationBase<CountryModel>(model)
{
    
}