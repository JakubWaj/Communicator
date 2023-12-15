using Application.DTO;
using MediatR;

namespace Application.Queries.User.GetUserByUsername;

public class GetUserByUsernameQuery : IRequest<UserDto>
{
    public string Username { get; set; }
}