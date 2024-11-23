using BaseBackend.API.Contracts.Categories;

namespace BaseBackend.API.Contracts.Products;

public record ProductsResponse( 
    Guid Id,
    string Name,
    decimal Price,
    string Description);