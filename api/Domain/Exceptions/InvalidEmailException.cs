namespace Domain.Exceptions;

public class InvalidEmailException(string email) : CustomException($"Invalid email: {email}")
{
}