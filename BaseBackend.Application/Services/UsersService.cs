using BaseBackend.Application.Interfaces;
using BaseBackend.Application.Interfaces.Services;
using BaseBackend.Application.Interfaces.Auth;
using BaseBackend.Core.Models;

namespace BaseBackend.Application.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;
    
    public UsersService(
        IUsersRepository usersRepository, 
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider)
    {
        _usersRepository = usersRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _usersRepository.GetAll();
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _usersRepository.GetByEmail(email);
    }

    public async Task<Guid> CreateUser(User user)
    {
        return await _usersRepository.Create(user);
    }

    public async Task<Guid> UpdateUser(Guid id, string name, string email, string password)
    {
        return await _usersRepository.Update(id, name, email, password);
    }

    public async Task<Guid> DeleteUser(Guid id)
    {
        return await _usersRepository.Delete(id);
    }

    public async Task Register(string userName, string email, string password)
    {
        var hashedPassword = _passwordHasher.Generate(password);

        var user = User.Create(Guid.NewGuid(), userName, email, hashedPassword);

        await _usersRepository.Create(user.user);
    }

    public async Task<string> Login(string email, string password)
    {
        //Refactor this later
        var user = await _usersRepository.GetByEmail(email);
        
        var result = _passwordHasher.Verify(password, user.PasswordHash);

        if (result == false)
        {
            throw new Exception("Failed to login");
        }

        var token = _jwtProvider.GenerateToken(user);
        
        return token;
    }
}