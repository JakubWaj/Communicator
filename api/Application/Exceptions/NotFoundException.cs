using Domain.Exceptions;

namespace Application.Exceptions;

public class NotFoundException : CustomException
{
    public NotFoundException() : base("Not found")
    {
    }
}