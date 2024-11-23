using BaseBackend.Core.Models;

namespace BaseBackend.Persistence.Postgres.Entities;

public class ProductEntity
{
    public Guid Id { get; set; }
    public string Name { get;  set; } = String.Empty;
    public decimal Price { get;  set; }
    public string Description { get;  set; } = String.Empty;
    public Guid CategoryId { get;  set; }
    public CategoryEntity? Category { get;  set; }
}