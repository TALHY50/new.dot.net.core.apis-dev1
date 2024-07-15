using ACL.Application.Domain.Auth;

namespace ACL.Application.Domain.Ports.Services.Token;

public interface IAuthTokenService
{
    Task<string> GenerateIdToken(AclUser user);
    Task<string> GenerateAccessToken(AclUser user);
    Task<string> GenerateRefreshToken();
    Task<string?> GetUserIdFromToken(string token);
    Task<int> GetRefreshTokenLifetimeInMinutes();
    Task<bool> IsTokenValid(string accessToken, bool validateLifeTime);
}