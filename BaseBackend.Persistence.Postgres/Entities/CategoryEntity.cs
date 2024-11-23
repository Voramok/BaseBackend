using BaseBackend.Core.Models;

namespace BaseBackend.Persistence.Postgres.Entities;

public class CategoryEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public List<ProductEntity> Products { get; set; } = new();
}