namespace Application.DTO;

public class GroupDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<UserDto> Users { get; set; }
    public ICollection<MessageDto> Messages { get; set; }
}