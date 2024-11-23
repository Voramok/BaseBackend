namespace BaseBackend.API.Contracts.Users;

public record UsersResponse( 
    Guid Id,
    string UserName,
    string Email,
    string Password);