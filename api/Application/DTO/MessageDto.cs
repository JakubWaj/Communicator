using Domain.ValueObjects.Message;

namespace Application.DTO;

public class MessageDto
{
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; }
}