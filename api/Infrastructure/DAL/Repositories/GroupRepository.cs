using System.Text.RegularExpressions;
using Domain.Entity;
using Domain.Repository;
using Domain.ValueObjects.Group;
using Domain.ValueObjects.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly ComContext _dbContext;

    public GroupRepository(ComContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ICollection<Groups>> GetByUserIdAsync(UserId userId)
    {
        return await _dbContext.GroupUsers.Where(x => x.UserId == userId).Select(x => x.Group).ToListAsync();
    }

    public async Task<Groups> GetByIdAsync(GroupId id)
    {
       return await _dbContext.Groups.Include(x=>x.Users).ThenInclude(x=>x.User).SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Groups group)
    {
        await _dbContext.Groups.AddAsync(group);
    }

    public async Task AddUserToGroupAsync(GroupUser groupUser)
    {
        await _dbContext.GroupUsers.AddAsync(groupUser);
    }
}