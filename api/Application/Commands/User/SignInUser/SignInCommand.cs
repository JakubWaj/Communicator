using Application.Abstraction;
using Domain.ValueObjects.User;

namespace Application.Commands.User.SignInUser;

public record SignInCommand(string Email,string Password) : ICommand
{
}