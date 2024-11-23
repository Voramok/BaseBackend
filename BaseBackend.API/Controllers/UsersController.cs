using BaseBackend.API.Contracts.Users;
using BaseBackend.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
        
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet]
    public async Task<ActionResult<List<UsersResponse>>> GetAllUsers()
    {
        var users = await _usersService.GetAllUsers();

        var response = users.Select(u => new UsersResponse(u.Id, u.UserName, u.Email, u.PasswordHash));

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateUser([FromBody] UsersRequest request)
    {
        var (user, error) = Core.Models.User.Create(Guid.NewGuid(), request.UserName, request.Email, request.Password);

        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var userId = await _usersService.CreateUser(user);

        return Ok(userId);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateUser(Guid id, [FromBody] UsersRequest request)
    {
        var userId = await _usersService.UpdateUser(id, request.UserName, request.Email, request.Password);

        return Ok(userId);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteUser(Guid id)
    {
        var userId = await _usersService.DeleteUser(id);

        return Ok(userId);
    }
}