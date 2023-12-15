using Domain.Entity;

namespace Application.DTO;

public static class Extensions
{
    public static UserDto AsDto(this User user)
    {
        return new UserDto()
        {
            Username = user.Username,
            Email = user.Email,
            Id = user.Id
        };
        
    }
}