using Application.DTO;
using Domain.Shared;
using MediatR;

namespace Application.Queries.User.GetUserByEmail;

public class GetUserByEmailQuery : IRequest<UserDto>
{
    public string Email { get; set; }
}