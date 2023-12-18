using Domain.Entity;
using Domain.ValueObjects.Group;
using Domain.ValueObjects.Message;

namespace Domain.Repository;

public interface IMessageRepository
{
    Task<Message> GetByIdAsync(MessageId id);
    Task<ICollection<Message>> GetByGroupIdAsync(GroupId groupId);
    Task AddAsync(Message message);
}