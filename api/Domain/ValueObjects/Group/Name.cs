using Domain.Exceptions;

namespace Domain.ValueObjects.Group;

public record Name
{
    public string Value { get; }

    public Name(string value)
    {
        if (value.Length > 50 || value.Length < 3 || string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidGroupNameException();
        }
        Value = value;
    }

    public static implicit operator Name(string value) => new(value);
    public static implicit operator string(Name name) => name.Value;
}