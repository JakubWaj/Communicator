using Domain.Shared;
using Domain.ValueObjects.Group;

namespace Domain.Entity;

public class Groups
{
    public GroupId Id { get; private set; }
    public Name Name { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    public ICollection<GroupUser> Users { get; private set; } = new List<GroupUser>();
    public ICollection<Message> Messages { get; private set; } = new List<Message>();

    public Groups(GroupId id, Name name, DateTime createdAt)
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
    }
}