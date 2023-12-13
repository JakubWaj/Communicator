namespace Domain.Entity;

public class Group
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public ICollection<User> Users { get; set; }
}