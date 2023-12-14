namespace Domain.Exceptions;

public class InvalidEntityIdException(object id) : CustomException($"Cannot set: {id}  as entity identifier.")
{
}