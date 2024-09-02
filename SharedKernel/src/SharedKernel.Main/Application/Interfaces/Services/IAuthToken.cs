namespace SharedKernel.Main.Application.Interfaces.Services;

public interface IAuthToken
{
    Task<string> GenerateIdToken(string nameIdentifier, string name, string email, string givenName, string surName);
    Task<string> GenerateAccessToken(string nameIdentifier, string? scope);
    Task<string> GenerateRefreshToken();
    Task<string?> GetUserIdFromToken(string token);
    Task<int> GetRefreshTokenLifetimeInMinutes();
    Task<bool> IsTokenValid(string accessToken, bool validateLifeTime);
    public string GenerateJwtToken(string keyId, string secretKey, string requestData, int seconds);
    public bool ValidateJwtToken(string token, string secretKey, string requestData);
}