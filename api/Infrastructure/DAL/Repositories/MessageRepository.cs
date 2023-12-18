using Domain.Entity;
using Domain.Repository;
using Domain.ValueObjects.Group;
using Domain.ValueObjects.Message;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly ComContext _dbContext;

    public MessageRepository(ComContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Message> GetByIdAsync(MessageId id)
    {
        return await _dbContext.Messages.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<Message>> GetByGroupIdAsync(GroupId groupId)
    {
        return await _dbContext.Messages.Where(x => x.GroupId == groupId).ToListAsync();
    }

    public async Task AddAsync(Message message)
    {
       await _dbContext.Messages.AddAsync(message);
    }
}