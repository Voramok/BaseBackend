namespace BaseBackend.Core.Models;

public class User
{
    public const int MAX_NAME_LENGTH = 30;
    private User(Guid id, string userName, string email, string passwordHash)
    {
        Id = id;
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
    }
    
    public Guid Id { get; set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }

    //To do validation for other fields
    public static (User user, string Error) Create(Guid id, string userName, string email, string passwordHash)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(userName) || userName.Length > MAX_NAME_LENGTH)
        {
            error = $"Name can't be empty or longer then {MAX_NAME_LENGTH} symbols";
        }
            
        var user = new User(id, userName, email, passwordHash);

        return (user, error);
    }
}