using Domain.Exceptions;

namespace Domain.ValueObjects.Message;

public record Content
{
    public string Value { get; }

    public Content(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidMessageContentException();
        }
        if (value.Length > 500)
        {
            throw new InvalidMessageContentException();
        }
        Value = value;
    }
    
    public static implicit operator string(Content content) => content.Value;
    public static implicit operator Content(string value) => new(value);
}