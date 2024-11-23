using BaseBackend.API.Contracts.Users;
using BaseBackend.Application.Interfaces.Services;

namespace BaseBackend.API.Endpoints;

public static class UsersEndpoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("register", Register);

        app.MapPost("login", Login);

        return app;
    }

    private static async Task<IResult> Register(RegisterUserRequest registerUserRequest, IUsersService usersService)
    {
        await usersService.Register(
            registerUserRequest.UserName, 
            registerUserRequest.Email, 
            registerUserRequest.Password);
        
        return Results.Ok();
    }
    
    private static async Task<IResult> Login(LoginUserRequest loginUserRequest, IUsersService usersService)
    {
        var token = await usersService.Login(loginUserRequest.Email, loginUserRequest.Password);
        
        return Results.Ok(token);
    }
}