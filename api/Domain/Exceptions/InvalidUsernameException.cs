namespace Domain.Exceptions;

public class InvalidUsernameException(string username) : CustomException($"Invalid username: {username}")
{
}