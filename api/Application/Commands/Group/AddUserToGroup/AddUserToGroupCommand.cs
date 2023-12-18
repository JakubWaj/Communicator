using Application.Abstraction;

namespace Application.Commands.Group.AddUserToGroup;

public class AddUserToGroupCommand : ICommand
{
    public Guid GroupId { get; set; }
    public Guid UserId { get; set; }
}