using System.Text.Json;

using LanguageExt;

using Messaging.Types;

using Microsoft.Extensions.Logging;

using RabbitMQ.Stream.Client;

namespace Messaging.Publisher;

internal class RabbitMqPublisherConfig<T> where T : notnull, IMessage
{
    public string Exchange { get; init; } = null!;
    public string Topic { get; init; } = "#";

    public string MessageName { get; } = T.Name;
}

internal class RabbitMqStreamPublisher<T> : IMessagePublisher<T> where T : class, IMessage
{
    private Producer _producer;
    private static readonly JsonSerializerOptions
        _options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    private readonly RabbitMqPublisherConfig<T> _config;
    private readonly ILogger<RabbitMqStreamPublisher<T>> _logger;
    private static readonly Dictionary<string, object> DefaultHeaders = new()
    {
        { "Content-Type", "application/json" },
        { "X-Message-Type", typeof(T).FullName! },
        { "X-Message-Name", T.Name }
    };
    public RabbitMqStreamPublisher(Producer producer, RabbitMqPublisherConfig<T> config, ILogger<RabbitMqStreamPublisher<T>> logger)
    {
        _producer = producer;
        _config = config;
        _logger = logger;
    }

    public async ValueTask<Unit> Publish(T message, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        var msg = JsonSerializer.SerializeToUtf8Bytes(message, _options);
        var id = await _producer.GetLastPublishingId();
        await _producer.Send(id + 1, new Message(msg));
        return Unit.Default;
    }
}