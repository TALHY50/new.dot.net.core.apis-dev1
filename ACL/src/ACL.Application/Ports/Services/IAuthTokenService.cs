using ACL.Core.Entities;
using ACL.Core.Entities.Auth;

namespace ACL.Application.Ports.Services;

public interface IAuthTokenService
{
    Task<string> GenerateIdToken(AclUser user);
    Task<string> GenerateAccessToken(AclUser user);
    Task<string> GenerateRefreshToken();
    Task<string?> GetUserIdFromToken(string token);
    Task<int> GetRefreshTokenLifetimeInMinutes();
    Task<bool> IsTokenValid(string accessToken, bool validateLifeTime);
}