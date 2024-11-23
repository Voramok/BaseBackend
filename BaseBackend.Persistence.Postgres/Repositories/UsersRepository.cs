using BaseBackend.Application.Interfaces;
using BaseBackend.Core.Models;
using BaseBackend.Persistence.Postgres.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseBackend.Persistence.Postgres.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly BaseBackendDbContext _context;
    
    public UsersRepository(BaseBackendDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAll()
    {
        var userEntities = await _context.Users
            .AsNoTracking()
            .ToListAsync();

        var users = userEntities
            .Select(u => User.Create(u.Id, u.UserName, u.Email, u.PasswordHash).user)
            .ToList();
        
        return users;
    }

    public async Task<User> GetByEmail(string email)
    {
        //Refactor this later
        var userEntity = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();

        var user = User.Create(userEntity.Id, userEntity.UserName, userEntity.Email, userEntity.PasswordHash).user;

        return user;
    }

    public async Task<Guid> Create(User user)
    {
        var userEntity = new UserEntity
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            PasswordHash = user.PasswordHash
        };

        await _context.Users.AddAsync(userEntity);
        await _context.SaveChangesAsync();

        return userEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string userName, string email, string password)
    {
        var userEntity = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);

        if (userEntity == null) return id;
        
        userEntity.UserName = userName;
        userEntity.Email = email;
        userEntity.PasswordHash = password;
            
        _context.Users.Update(userEntity);
        await _context.SaveChangesAsync();

        return id;
    }
    
    public async Task<Guid> Delete(Guid id)
    {
        var userEntity = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
        
        if (userEntity == null) return id;
        
        _context.Users.Remove(userEntity);
        await _context.SaveChangesAsync();

        return id;
    }
}