using Domain.Entity;
using Domain.ValueObjects.User;

namespace Domain.Repository;

public interface IUserRepository
{
    Task<ICollection<User>> GetAllUsersAsync();
    Task<User> GetByIdAsync(UserId id);
    Task<User> GetByEmailAsync(Email email);
    Task<User> GetByUsernameAsync(Username username);
    Task AddAsync(User user);
    Task<bool> ExistsAsync(Email email);
}