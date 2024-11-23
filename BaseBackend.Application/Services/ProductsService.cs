using BaseBackend.Application.Interfaces;
using BaseBackend.Application.Interfaces.Auth;
using BaseBackend.Application.Interfaces.Services;
using BaseBackend.Core.Models;

namespace BaseBackend.Application.Services;

public class ProductsService : IProductsService
{
    private readonly IProductsRepository _productsRepository;

    public ProductsService(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<List<Product>> GetAllProducts()
    {
        return await _productsRepository.GetAll();
    }

    public async Task<Product> GetProductByName(string name)
    {
        return await _productsRepository.GetByName(name);
    }
    
    public async Task<Product> GetProductById(Guid id)
    {
        return await _productsRepository.GetById(id);
    }

    public async Task<Guid> CreateProduct(Product product, Guid categoryId)
    {
        return await _productsRepository.Create(product, categoryId);
    }

    public async Task<Guid> UpdateProduct(Guid id, string name, decimal price, string description, Guid categoryId)
    {
        return await _productsRepository.Update(id, name, price, description, categoryId);
    }

    public async Task<Guid> DeleteProduct(Guid id)
    {
        return await _productsRepository.Delete(id);
    }
}