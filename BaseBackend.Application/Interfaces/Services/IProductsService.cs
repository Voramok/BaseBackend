using BaseBackend.Core.Models;

namespace BaseBackend.Application.Interfaces.Services;

public interface IProductsService
{
    Task<Guid> CreateProduct(Product product, Guid categoryId);
    Task<Guid> DeleteProduct(Guid id);
    Task<List<Product>> GetAllProducts();
    Task<Product> GetProductByName(string name);
    Task<Product> GetProductById(Guid id);
    Task<Guid> UpdateProduct(Guid id, string name, decimal price, string description, Guid categoryId);
}