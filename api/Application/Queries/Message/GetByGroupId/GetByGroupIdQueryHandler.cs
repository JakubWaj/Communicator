using Application.DTO;
using Domain.Repository;
using Domain.ValueObjects.Group;
using MediatR;

namespace Application.Queries.Message.GetByGroupId;

public class GetByGroupIdQueryHandler : IRequestHandler<GetByGroupIdQuery, ICollection<MessageDto>>
{
    private readonly IMessageRepository _messageRepository;
    private readonly IGroupRepository _groupRepository;

    public GetByGroupIdQueryHandler(IMessageRepository messageRepository, IGroupRepository groupRepository)
    {
        _messageRepository = messageRepository;
        _groupRepository = groupRepository;
    }
    
    public async Task<ICollection<MessageDto>> Handle(GetByGroupIdQuery request, CancellationToken cancellationToken)
    {
        GroupId groupId = new(request.GroupId);
        var messeges = await _messageRepository.GetByGroupIdAsync(groupId);
        var messagesDto = messeges.Select(x => x.AsDto()).ToList();
        return messagesDto;
    }
}