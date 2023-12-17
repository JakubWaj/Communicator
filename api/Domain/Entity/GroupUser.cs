using Domain.ValueObjects.Group;
using Domain.ValueObjects.User;

namespace Domain.Entity;

public class GroupUser
{
    public GroupId GroupId { get; set; }
    public Groups Group { get; set; }
    public UserId UserId { get; set; }
    public User User { get; set; }
}