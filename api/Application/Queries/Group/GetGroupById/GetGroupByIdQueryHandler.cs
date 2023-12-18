using Application.DTO;
using Application.Exceptions;
using Domain.Repository;
using Domain.Shared;
using Domain.ValueObjects.Group;
using MediatR;

namespace Application.Queries.Group.GetGroupById;

public class GetGroupByIdQueryHandler : IRequestHandler<GetGroupByIdQuery,GroupDto>
{
    private readonly IGroupRepository _groupRepository;

    public GetGroupByIdQueryHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    
    public async Task<GroupDto> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var group = await _groupRepository.GetByIdAsync(new GroupId(request.GroupId));
        if (group is null)
        {
            throw new NotFoundException();
        }
        return group.AsDto();
    }
}