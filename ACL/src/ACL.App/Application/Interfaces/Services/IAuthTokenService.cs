using ACL.App.Domain.Entities;

namespace ACL.App.Application.Interfaces.Services;

public interface IAuthTokenService
{
    Task<string> GenerateIdToken(User user);
    Task<string> GenerateAccessToken(User user);
    Task<string> GenerateRefreshToken();
    Task<string?> GetUserIdFromToken(string token);
    Task<int> GetRefreshTokenLifetimeInMinutes();
    Task<bool> IsTokenValid(string accessToken, bool validateLifeTime);
}