using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications.Base;

public class NotificationBase<TModel>(TModel model) : INotification<TModel> where TModel : class, IModel
{
    public TModel Model  => model;
}