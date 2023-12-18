namespace Application.DTO;

public class GroupDto
{
    public string Name { get; set; }
    public ICollection<UserDto> Users { get; set; }
    public ICollection<MessageDto> Messages { get; set; }
}