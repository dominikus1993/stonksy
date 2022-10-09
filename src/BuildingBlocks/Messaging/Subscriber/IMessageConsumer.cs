using LanguageExt;

using Messaging.Types;

namespace Messaging.Subscriber;

public interface IMessageConsumer<T> where T : notnull, IMessage
{
    Task<Unit> Handle(T message, CancellationToken cancellationToken = default);
}