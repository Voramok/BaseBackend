using BaseBackend.Core.Models;

namespace BaseBackend.Application.Interfaces;

public interface IProductsRepository
{
    Task<Guid> Create(Product product, Guid categoryId);
    Task<Guid> Delete(Guid id);
    Task<List<Product>> GetAll();
    Task<Product> GetByName(string name);
    Task<Product> GetById(Guid id);
    Task<Guid> Update(Guid id, string name, decimal price, string description, Guid categoryId);
}