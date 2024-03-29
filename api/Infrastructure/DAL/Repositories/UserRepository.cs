﻿using Domain.Entity;
using Domain.Repository;
using Domain.ValueObjects.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbSet<User> _users;

    public UserRepository(ComContext dbContext)
    {
        _users = dbContext.Users;
    }

    public async Task<ICollection<User>> GetAllUsersAsync()
    {
        return await _users.ToListAsync();
    }

    public Task<User> GetByIdAsync(UserId id)
        => _users.SingleOrDefaultAsync(x => x.Id == id);

    public Task<User> GetByEmailAsync(Email email)
        => _users.SingleOrDefaultAsync(x => x.Email == email);

    public Task<User> GetByUsernameAsync(Username username)
        => _users.SingleOrDefaultAsync(x => x.Username == username);

    public async Task AddAsync(User user)
        => await _users.AddAsync(user);

    public Task<bool> ExistsAsync(Email email)
    {
        return _users.AnyAsync(x => x.Email == email);
    }
}