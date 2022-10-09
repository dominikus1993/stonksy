using System.Text.Json;

using LanguageExt;

using Messaging.Types;

using RabbitMQ.Stream.Client;

namespace Messaging.Publisher;

public class RabbitMqStreamPublisher<T> : IMessagePublisher<T> where T : class, IMessage
{
    private Producer _producer;
    private static readonly JsonSerializerOptions
        _options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    private readonly RabbitMqPublisherConfig<T> _config;
    private readonly ILogger<RabbitMqMessagePublisher<T>> _logger;
    private static readonly Dictionary<string, object> DefaultHeaders = new()
    {
        { "Content-Type", "application/json" },
        { "X-Message-Type", typeof(T).FullName },
        { "X-Message-Name", T.Name }
    };
    public RabbitMqStreamPublisher(Producer producer)
    {
        _producer = producer;
    }

    public async ValueTask<Unit> Publish(T message, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        var id = await _producer.GetLastPublishingId();
        var jsonMessage = JsonCon
        await _producer.Send(id + 1, new Message());
    }
}