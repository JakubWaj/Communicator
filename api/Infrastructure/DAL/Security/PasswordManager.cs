using Application.Security;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.DAL.Security;

public class PasswordManager : IPasswordManager
{
    private readonly IPasswordHasher<User> _passwordHasher;

    public PasswordManager(IPasswordHasher<User> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public string Secure(string password) => _passwordHasher.HashPassword(null, password);

    public bool Validate(string password, string securedPassword) => _passwordHasher.VerifyHashedPassword(null, securedPassword, password) == PasswordVerificationResult.Success;
}