using Application.DTO;
using MediatR;

namespace Application.Queries.Group.GetGroupsByUser;

public class GetGroupsByUserQuery : IRequest<ICollection<GroupDto>>
{
    public Guid UserId { get; set; }
}