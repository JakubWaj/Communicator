using Application.DTO;
using MediatR;

namespace Application.Queries.User.GetAllUsers;

public class GetAllUsersQuery : IRequest<ICollection<UserDto>>
{
    
}