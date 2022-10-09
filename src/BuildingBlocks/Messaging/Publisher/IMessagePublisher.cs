using LanguageExt;

using Messaging.Types;

namespace Messaging.Publisher;

public interface IMessagePublisher<T> where T : class, IMessage
{
    ValueTask<Unit> Publish(T message, CancellationToken cancellationToken = default);
}