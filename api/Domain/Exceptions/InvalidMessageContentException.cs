namespace Domain.Exceptions;

public class InvalidMessageContentException : CustomException
{
    public InvalidMessageContentException() : base("Invalid message content.")
    {
    }
}