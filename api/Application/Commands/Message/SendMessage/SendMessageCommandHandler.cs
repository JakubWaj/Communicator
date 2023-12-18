using Application.Abstraction;
using Domain.Repository;
using Domain.Shared;
using Domain.ValueObjects.Group;
using Domain.ValueObjects.Message;
using Domain.ValueObjects.User;

namespace Application.Commands.Message.SendMessage;

public class SendMessageCommandHandler : ICommandHandler<SendMessageCommand>
{
    private readonly IMessageRepository _messageRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SendMessageCommandHandler(IMessageRepository messageRepository,IUnitOfWork unitOfWork)
    {
        _messageRepository = messageRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        UserId userId = new(request.UserId);
        GroupId groupId = new(request.GroupId);
        Content content = new(request.Content);
        MessageId messageId = new(Guid.NewGuid());
        Domain.Entity.Message message = new Domain.Entity.Message()
        {
            Id = messageId,
            Content = content,
            GroupId = groupId,
            UserId = userId,
            CreatedAt = DateTime.Now.ToUniversalTime()
        };
        await _messageRepository.AddAsync(message);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}