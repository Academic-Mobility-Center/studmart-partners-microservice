using System.Text;
using System.Text.Json;
using AutoMapper;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Helpers;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models.Base;
using StudMart.PartnersMicroservice.Synchronization.Abstractions;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Base;

public abstract class SynchronizationServiceBase<TModel, TServiceModel> : ISynchronizationService<TModel>
    where TModel : class, IModel where TServiceModel : class, IServiceModel
{
    private readonly ConnectionFactory _connectionFactory;
    private const string Exchange = "StudMart.Exchange";
    private readonly IMapper _mapper;
    private readonly string _routingKey;

    protected SynchronizationServiceBase(IOptions<RabbitSettings> options, IMapper mapper, string routingKey)
    {
        _connectionFactory = new ConnectionFactory
        {
            UserName = options.Value.User,
            Password = options.Value.Password,
            Port = options.Value.Port,
            HostName = options.Value.Server,
            VirtualHost = options.Value.VirtualHost,
        };
        _mapper = mapper;
        _routingKey = routingKey;
    }

    public async Task SendAsync(TModel entity, CancellationToken cancellationToken = default)
    {
        await using var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken);
        if (connection.IsOpen)
        {
            await using var channel = await connection.CreateChannelAsync(cancellationToken: cancellationToken);
            await channel.ExchangeDeclareAsync(Exchange, ExchangeType.Direct, cancellationToken: cancellationToken);
            var model = _mapper.Map<TServiceModel>(entity);
            var body = JsonSerializer.Serialize(model);
            var bytes = Encoding.UTF8.GetBytes(body);
            await channel.BasicPublishAsync(exchange: Exchange, routingKey: _routingKey, body: bytes, cancellationToken: cancellationToken);
        }
    }
}