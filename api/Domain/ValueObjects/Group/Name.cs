using Domain.Exceptions;

namespace Domain.ValueObjects.Group;

public class Name
{
    public string Value { get; }

    public Name(string value)
    {
        if (Value.Length > 50 || Value.Length < 3)
        {
            throw new InvalidGroupNameException();
        }
    }
}