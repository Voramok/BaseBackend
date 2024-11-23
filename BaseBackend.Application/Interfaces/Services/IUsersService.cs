using BaseBackend.Core.Models;

namespace BaseBackend.Application.Interfaces.Services;

public interface IUsersService
{
    Task<Guid> CreateUser(User user);
    Task<Guid> DeleteUser(Guid id);
    Task<List<User>> GetAllUsers();
    Task<User> GetUserByEmail(string email);
    Task<Guid> UpdateUser(Guid id, string name, string email, string password);
    Task Register(string userName, string email, string password);
    Task<string> Login(string email, string password);
}