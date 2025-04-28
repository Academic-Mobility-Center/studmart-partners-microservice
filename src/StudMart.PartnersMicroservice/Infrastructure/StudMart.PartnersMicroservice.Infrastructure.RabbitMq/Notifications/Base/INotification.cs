using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications.Base;

public interface INotification<out TModel> : INotification where TModel : class, IModel
{
    public TModel Model { get; }
}