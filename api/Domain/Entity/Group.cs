namespace Domain.Entity;

public class Group : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<GroupMember> Users { get; set; }
    public ICollection<Message> Messages { get; set; }
}