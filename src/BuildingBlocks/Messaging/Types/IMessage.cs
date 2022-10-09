namespace Messaging.Types;

public interface IMessage
{
    Guid MessageId { get; init; }
    DateTime CreatedAt { get; init; }
    static abstract string Name { get; }
}