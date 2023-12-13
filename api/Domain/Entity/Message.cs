namespace Domain.Entity;

public class Message : BaseEntity
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public Guid SenderId { get; set; }
    public User Sender { get; set; }
    public Guid GroupId { get; set; }
    public Group Group { get; set; }
}