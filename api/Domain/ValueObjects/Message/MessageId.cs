using Domain.Exceptions;

namespace Domain.ValueObjects.Message;

public record MessageId
{
     public MessageId(Guid value)
     {
          if (value == Guid.Empty)
          {
               throw new InvalidEntityIdException(value);
          }
          Value = value;
     }
     public Guid Value { get; }
     
     public static implicit operator Guid(MessageId date) => date.Value;
     public static implicit operator MessageId(Guid value) => new(value);
}