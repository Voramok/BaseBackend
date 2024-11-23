using BaseBackend.Application.Interfaces;
using BaseBackend.Core.Models;
using BaseBackend.Persistence.Postgres.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseBackend.Persistence.Postgres.Repositories;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly BaseBackendDbContext _context;
    
    public CategoriesRepository(BaseBackendDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAll()
    {
        var categoryEntities = await _context.Categories
            .AsNoTracking()
            .ToListAsync();

        var categories = categoryEntities
            .Select(c => Category.Create(c.Id, c.Name, c.Description).category)
            .ToList();
        
        return categories;
    }
    
    public async Task<Category> GetById(Guid id)
    {
        //Refactor this later
        var categoryEntity = await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception();

        var category = Category.Create(categoryEntity.Id, categoryEntity.Name, 
            categoryEntity.Description).category;

        return category;
    }

    public async Task<Category> GetByName(string name)
    {
        //Refactor this later
        var categoryEntity = await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Name == name) ?? throw new Exception();

        var category = Category.Create(categoryEntity.Id, categoryEntity.Name, 
            categoryEntity.Description).category;

        return category;
    }

    public async Task<Guid> Create(Category category)
    {
        var categoryEntity = new CategoryEntity()
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };

        await _context.Categories.AddAsync(categoryEntity);
        await _context.SaveChangesAsync();

        return categoryEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string name, string description)
    {
        var categoryEntity = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == id);

        if (categoryEntity == null) return id;
        
        categoryEntity.Name = name;
        categoryEntity.Description = description;

        _context.Categories.Update(categoryEntity);
        await _context.SaveChangesAsync();

        return id;
    }
    
    public async Task<Guid> Delete(Guid id)
    {
        var categoryEntity = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == id);
        
        if (categoryEntity == null) return id;
        
        _context.Categories.Remove(categoryEntity);
        await _context.SaveChangesAsync();

        return id;
    }
}