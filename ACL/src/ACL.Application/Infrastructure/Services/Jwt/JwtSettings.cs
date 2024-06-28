namespace ACL.Application.Infrastructure.Services.Jwt
{
    public class JwtSettings
    {
        public required AccessTokenSettings AccessTokenSettings { get; set; }
        public required RefreshTokenSettings RefreshTokenSettings { get; set; }
    }

    public class AccessTokenSettings
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public long LifeTimeInSeconds { get; set; }
        public string? PublicKey { get; set; }
        public string? PrivateKey { get; set; }
    }

    public class RefreshTokenSettings
    {
        public int Length { get; set; }
        public int LifeTimeInMinutes { get; set; }
    }
}