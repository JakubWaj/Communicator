namespace Domain.Exceptions;

public class InvalidGroupNameException : CustomException
{
    public InvalidGroupNameException() : base("Invalid group name.")
    {
    }
}