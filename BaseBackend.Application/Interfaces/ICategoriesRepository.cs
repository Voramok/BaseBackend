using BaseBackend.Core.Models;

namespace BaseBackend.Application.Interfaces;

public interface ICategoriesRepository
{
    Task<Guid> Create(Category category);
    Task<Guid> Delete(Guid id);
    Task<List<Category>> GetAll();
    Task<Category> GetByName(string name);
    Task<Category> GetById(Guid id);
    Task<Guid> Update(Guid id, string name, string description);
}