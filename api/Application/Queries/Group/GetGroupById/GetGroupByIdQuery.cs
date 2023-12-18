using Application.DTO;
using Domain.Entity;
using MediatR;

namespace Application.Queries.Group.GetGroupById;

public class GetGroupByIdQuery : IRequest<GroupDto>
{
    public Guid GroupId { get; set; }
}