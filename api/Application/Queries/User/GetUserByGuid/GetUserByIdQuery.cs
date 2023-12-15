using Application.DTO;
using MediatR;

namespace Application.Queries.User.GetUserByGuid;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public Guid Id { get; set; }   
}