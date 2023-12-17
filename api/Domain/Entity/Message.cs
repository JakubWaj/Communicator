using System.Text.RegularExpressions;
using Domain.ValueObjects.Group;
using Domain.ValueObjects.Message;
using Domain.ValueObjects.User;

namespace Domain.Entity;

public class Message
{
    public MessageId MessageId { get; set; }
    public Content Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public GroupId GroupId { get; set; }
    public Groups Group { get; set; }    
    public UserId UserId { get; set; }
    public User User { get; set; }
    
}