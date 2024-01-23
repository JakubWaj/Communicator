using System.Text.RegularExpressions;
using Domain.Entity;
using Domain.ValueObjects.Group;
using Domain.ValueObjects.User;

namespace Domain.Repository;

public interface IGroupRepository
{
    Task<ICollection<Groups>> GetByUserIdAsync(UserId userId);
    Task<Groups> GetByIdAsync(GroupId id);
    Task AddAsync(Groups group);
    Task AddUserToGroupAsync(GroupUser groupUser);
    
}