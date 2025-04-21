using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Handlers.Base;

public interface ICreatedNotificationHandler<in TNotification, TModel> : INotificationHandler<TNotification>
where TNotification : ICreatedNotification<TModel>
where TModel : class, IModel
{
    
}