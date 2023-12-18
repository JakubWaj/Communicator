using Application.DTO;
using Domain.Repository;
using Domain.ValueObjects.Message;
using MediatR;

namespace Application.Queries.Message.GetById;

public class GetByIdQueryCommand : IRequestHandler<GetByIdQuery,MessageDto>
{
    private readonly IMessageRepository _messageRepository;

    public GetByIdQueryCommand(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }
    
    public async Task<MessageDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        MessageId messageId = new(request.Id);
        var message =await _messageRepository.GetByIdAsync(messageId);
        return message.AsDto();
    }
}