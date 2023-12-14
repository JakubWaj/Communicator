using Domain.ValueObjects.User;

namespace Domain.Entity;

public class User
{
    public UserId Id { get;private set; }
    public Username Username { get;private set; }
    public Email Email { get;private set; }
    public Password Password { get;private set; }
    public DateTime CreatedAt { get;private set; }


    public User(UserId id, Username username, Email email, Password password, DateTime createdAt)
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
        CreatedAt = createdAt;
    }
}