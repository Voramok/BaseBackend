namespace BaseBackend.API.Contracts.Users;

public record UsersRequest(
    string UserName,
    string Email,
    string Password);