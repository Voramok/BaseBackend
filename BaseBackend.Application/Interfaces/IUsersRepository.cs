using BaseBackend.Core.Models;

namespace BaseBackend.Application.Interfaces;

public interface IUsersRepository
{
    Task<Guid> Create(User user);
    Task<Guid> Delete(Guid id);
    Task<List<User>> GetAll();
    Task<User> GetByEmail(string email);
    Task<Guid> Update(Guid id, string name, string email, string password);
}