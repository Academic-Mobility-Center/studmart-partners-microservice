using System.Text;
using System.Text.Json;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Helpers;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models.Base;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Handlers.Base;

public abstract class
    NotificationHandlerBase<TNotification, TModel, TServiceModel>(
        IOptions<RabbitSettings> options,
        IMapper mapper,
        string routingKey,
        ILogger<INotificationHandler<TNotification, TModel>> logger)
    : INotificationHandler<TNotification, TModel>
    where TModel : class, IModel
    where TNotification : INotification<TModel>
    where TServiceModel : class, IServiceModel
{
    private readonly ConnectionFactory _connectionFactory = new()
    {
        UserName = options.Value.User,
        Password = options.Value.Password,
        Port = options.Value.Port,
        HostName = options.Value.Server,
        VirtualHost = options.Value.VirtualHost,
    };
    private const string Exchange = "StudMart.Exchange";

    public async Task Handle(TNotification notification, CancellationToken cancellationToken)
    {
        await using var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken);
        if (connection.IsOpen)
        {
            var entity = notification.Model;
            await using var channel = await connection.CreateChannelAsync(cancellationToken: cancellationToken);
            await channel.ExchangeDeclareAsync(Exchange, ExchangeType.Direct, cancellationToken: cancellationToken);
            var model = mapper.Map<TServiceModel>(entity);
            var body = JsonSerializer.Serialize(model);
            logger.LogInformation(body);
            var bytes = Encoding.UTF8.GetBytes(body);
            await channel.BasicPublishAsync(exchange: Exchange, routingKey: routingKey, body: bytes, cancellationToken: cancellationToken);
            logger.LogInformation("Published {RoutingKey} {ServiceModel}", routingKey, model);
        }
    }
}