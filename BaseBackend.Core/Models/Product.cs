namespace BaseBackend.Core.Models;

public class Product
{
    public const int MAX_NAME_LENGTH = 30;
    private Product(Guid id, string name, decimal price, string description, Guid categoryId)
    {
        Id = id;
        Name = name;
        Price = price;
        Description = description;
        CategoryId = categoryId;
    }
    
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }

    //To do validation for other fields
    public static (Product product, string Error) Create(
        Guid id, string name, decimal price, string description, Guid categoryId)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
        {
            error = $"Name can't be empty or longer then {MAX_NAME_LENGTH} symbols";
        }
            
        var product = new Product(id, name, price, description, categoryId);

        return (product, error);
    }
}