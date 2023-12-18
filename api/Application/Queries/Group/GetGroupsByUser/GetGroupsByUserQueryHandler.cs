using Application.DTO;
using Domain.Repository;
using Domain.ValueObjects.User;
using MediatR;

namespace Application.Queries.Group.GetGroupsByUser;

public class GetGroupsByUserQueryHandler : IRequestHandler<GetGroupsByUserQuery,ICollection<GroupDto>>
{
    private readonly IGroupRepository _groupRepository;

    public GetGroupsByUserQueryHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    
    public async Task<ICollection<GroupDto>> Handle(GetGroupsByUserQuery request, CancellationToken cancellationToken)
    {
        var groups = await _groupRepository.GetByUserIdAsync(new UserId(request.UserId));
        return groups.Select(x => x.AsDto()).ToList();
    }
}