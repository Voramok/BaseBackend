using BaseBackend.API.Contracts.Products;

namespace BaseBackend.API.Contracts.Categories;

public record CategoriesRequest(
    string Name,
    string Description);