using Domain.Exceptions;
using Domain.ValueObjects.Message;

namespace Domain.ValueObjects.Group;

public record GroupId
{
    
    public GroupId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }
        Value = value;
    }
    public Guid Value { get; }
     
    public static implicit operator Guid(GroupId date) => date.Value;
    public static implicit operator GroupId(Guid value) => new(value);
}