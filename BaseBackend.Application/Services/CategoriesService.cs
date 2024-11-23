using BaseBackend.Application.Interfaces;
using BaseBackend.Application.Interfaces.Services;
using BaseBackend.Core.Models;

namespace BaseBackend.Application.Services;

public class CategoriesService : ICategoriesService
{
    private readonly ICategoriesRepository _categoriesRepository;

    public CategoriesService(ICategoriesRepository categoriesRepository)
    {
        _categoriesRepository = categoriesRepository;
    }

    public async Task<List<Category>> GetAllCategories()
    {
        return await _categoriesRepository.GetAll();
    }

    public async Task<Category> GetCategoryByName(string name)
    {
        return await _categoriesRepository.GetByName(name);
    }
    
    public async Task<Category> GetCategoryById(Guid id)
    {
        return await _categoriesRepository.GetById(id);
    }

    public async Task<Guid> CreateCategory(Category category)
    {
        return await _categoriesRepository.Create(category);
    }

    public async Task<Guid> UpdateCategory(Guid id, string name, string description)
    {
        return await _categoriesRepository.Update(id, name, description);
    }

    public async Task<Guid> DeleteCategory(Guid id)
    {
        return await _categoriesRepository.Delete(id);
    }
}