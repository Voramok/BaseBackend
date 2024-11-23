using BaseBackend.Application.Interfaces;
using BaseBackend.Core.Models;
using BaseBackend.Persistence.Postgres.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseBackend.Persistence.Postgres.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly BaseBackendDbContext _context;
    
    public ProductsRepository(BaseBackendDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAll()
    {
        var productEntities = await _context.Products
            .AsNoTracking()
            .ToListAsync();

        var products = productEntities
            .Select(p => Product.Create(p.Id, p.Name, p.Price, p.Description, p.CategoryId).product)
            .ToList();
        
        return products;
    }
    
    public async Task<Product> GetById(Guid id)
    {
        //Refactor this later
        var productEntity = await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id) ?? throw new Exception();

        var product = Product.Create(productEntity.Id, productEntity.Name, productEntity.Price, 
            productEntity.Description, productEntity.CategoryId).product;

        return product;
    }

    public async Task<Product> GetByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }

        var productEntity = await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Name == name);
        
        if (productEntity == null)
        {
            throw new KeyNotFoundException($"Product with name '{name}' not found.");
        }

        var (product, error) = Product.Create(productEntity.Id, productEntity.Name, productEntity.Price, 
            productEntity.Description, productEntity.CategoryId);
        
        if (!string.IsNullOrEmpty(error))
        {
            throw new InvalidOperationException(error);
        }

        return product;
    }

    public async Task<Guid> Create(Product product, Guid categoryId)
    {
        var category = await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == categoryId) ?? throw new Exception();
        
        var productEntity = new ProductEntity
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            CategoryId = categoryId
        };

        
        await _context.Products.AddAsync(productEntity);
        await _context.SaveChangesAsync();

        return productEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string name, decimal price, string description, Guid categoryId)
    {
        var productEntity = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id);

        if (productEntity == null) return id;
        
        productEntity.Name = name;
        productEntity.Price = price;
        productEntity.Description = description;
        productEntity.CategoryId = categoryId;
            
        _context.Products.Update(productEntity);
        await _context.SaveChangesAsync();

        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        var productEntity = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (productEntity == null) return id;
        
        _context.Products.Remove(productEntity);
        await _context.SaveChangesAsync();

        return id;
    }
}