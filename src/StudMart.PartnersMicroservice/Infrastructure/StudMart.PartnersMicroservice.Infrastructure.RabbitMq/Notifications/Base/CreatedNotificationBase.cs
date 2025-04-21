using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications.Base;

public class CreatedNotificationBase<TModel>(TModel model) : ICreatedNotification<TModel> where TModel : class, IModel
{
    public TModel Model  => model;
}