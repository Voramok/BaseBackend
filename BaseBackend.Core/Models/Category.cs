namespace BaseBackend.Core.Models;

public class Category
{
    public const int MAX_NAME_LENGTH = 30;
    private Category(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
    
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    //To do validation for other fields
    public static (Category category, string Error) Create(Guid id, string name, string description)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
        {
            error = $"Name can't be empty or longer then {MAX_NAME_LENGTH} symbols";
        }
            
        var category = new Category(id, name, description);

        return (category, error);
    }
}