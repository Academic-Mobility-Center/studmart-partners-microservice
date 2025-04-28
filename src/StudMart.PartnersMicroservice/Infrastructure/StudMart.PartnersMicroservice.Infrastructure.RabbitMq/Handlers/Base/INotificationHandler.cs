using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Handlers.Base;

public interface INotificationHandler<in TNotification, TModel> : INotificationHandler<TNotification>
where TNotification : INotification<TModel>
where TModel : class, IModel
{
    
}