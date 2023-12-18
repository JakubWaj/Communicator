using Application.Abstraction;
using Domain.ValueObjects.User;

namespace Application.Commands.Group.CreateGroup;

public class CreateGroupCommand : ICommand
{
    public Guid UserId { get; set; }
    public Guid OtherUserId { get; set; }
    public string Name { get; set; } 
}