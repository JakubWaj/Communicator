using Application.Abstraction;
using Domain.ValueObjects.User;

namespace Application.Commands.User.SignUpUser;

public record SignUpCommand(Guid UserId, string Email, string Username, string Password) : ICommand
{
}