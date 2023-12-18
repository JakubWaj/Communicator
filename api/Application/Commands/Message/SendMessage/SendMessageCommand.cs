using Application.Abstraction;

namespace Application.Commands.Message.SendMessage;

public class SendMessageCommand : ICommand
{
    public Guid GroupId { get; set; }
    public string Content { get; set; }
    public Guid UserId { get; set; }
}