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
    
    public static GroupDto AsDto(this Groups group)
    {
        var users = group.Users;
        return new GroupDto()
        {
            Name = group.Name,
            Messages = group.Messages.Select(x => x.AsDto()).ToList(),
            Users = group.Users.Select(x => x.User.AsDto()).ToList()
        };
    }
    
    public static MessageDto AsDto(this Message message)
    {
        return new MessageDto()
        {
            Content = message.Content,
            CreatedAt = message.CreatedAt,
            UserId = message.UserId
        };
    }
}