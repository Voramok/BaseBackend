using System.ComponentModel.DataAnnotations;

namespace BaseBackend.API.Contracts.Users;

public record LoginUserRequest(
    [Required] string Email,
    [Required] string Password);