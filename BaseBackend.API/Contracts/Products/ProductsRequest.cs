using BaseBackend.API.Contracts.Categories;

namespace BaseBackend.API.Contracts.Products;

public record ProductsRequest(
    string Name,
    decimal Price,
    string Description,
    Guid CategoryId);