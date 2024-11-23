using BaseBackend.Core.Models;

namespace BaseBackend.Application.Interfaces.Auth;

public interface IJwtProvider
{
    string GenerateToken(User user);
}