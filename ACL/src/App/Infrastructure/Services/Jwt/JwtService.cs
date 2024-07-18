using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using App.Application.Common.Exceptions;
using App.Domain.Auth;
using App.Domain.Ports.Services.Token;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Claim = App.Domain.Auth.Claim;

namespace App.Infrastructure.Services.Jwt
{
    public class JwtService(IOptions<JwtSettings> settings, RsaSecurityKey rsaSecurityKey)
        : IAuthTokenService
    {
        public static readonly string VersionClaimType = "ver";

        public Task<string> GenerateAccessToken(AclUser user)
        {
            var signingCredentials = new SigningCredentials(
                key: rsaSecurityKey,
                algorithm: SecurityAlgorithms.RsaSha256
            );

            var claimsIdentity = new ClaimsIdentity();

            // Access Token must only carry the user Id
            claimsIdentity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            
            // Add scope claim, which contains an array of scopes
            var scope = user.Claims.SingleOrDefault(c => c.Type == "scope");
            if (scope != null)
            {
                claimsIdentity.AddClaim(new System.Security.Claims.Claim("scope", string.Join(" ", scope.Value)));
            }

            /*var version = user.PermissionVersion;
            claimsIdentity.AddClaim(new System.Security.Claims.Claim(VersionClaimType, version.ToString()));*/

            var jwtHandler = new JwtSecurityTokenHandler();

            var jwt = jwtHandler.CreateJwtSecurityToken(
                issuer: settings.Value.AccessTokenSettings.Issuer,
                audience: settings.Value.AccessTokenSettings.Audience,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                // expires: DateTime.UtcNow.AddSeconds(settings.Value.AccessTokenSettings.LifeTimeInSeconds),
               expires: DateTime.UtcNow.AddSeconds(999999),
                issuedAt: DateTime.UtcNow,
                signingCredentials: signingCredentials);

            var serializedJwt = jwtHandler.WriteToken(jwt);

            return Task.FromResult(serializedJwt);
        }

        public Task<string> GenerateIdToken(AclUser user)
        {
            var signingCredentials = new SigningCredentials(
                key: rsaSecurityKey,
                algorithm: SecurityAlgorithms.RsaSha256
            );

            var claimsIdentity = new ClaimsIdentity();

            claimsIdentity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claimsIdentity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.Name, user?.FirstName??""));
            claimsIdentity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.Email, user?.Email??""));
            claimsIdentity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.GivenName, user?.LastName??""));
            claimsIdentity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.Surname, user?.LastName??""));

            // Add custom claims if any
            foreach (var c in user?.Claims ?? System.Linq.Enumerable.Empty<Claim>())
            {
                claimsIdentity.AddClaim(new System.Security.Claims.Claim(c.Type, c.Value));
            }

            var jwtHandler = new JwtSecurityTokenHandler();

            var jwt = jwtHandler.CreateJwtSecurityToken(
                issuer: settings.Value.AccessTokenSettings.Issuer,
                audience: settings.Value.AccessTokenSettings.Audience,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddSeconds(settings.Value.AccessTokenSettings.LifeTimeInSeconds),
                issuedAt: DateTime.UtcNow,
                signingCredentials: signingCredentials);

            var serializedJwt = jwtHandler.WriteToken(jwt);

            return Task.FromResult(serializedJwt);
        }

        public Task<string> GenerateRefreshToken()
        {
            var size = settings.Value.RefreshTokenSettings.Length;
            var buffer = new byte[size];
            using var rng =  RandomNumberGenerator.Create();
            rng.GetBytes(buffer);
            return Task.FromResult(Convert.ToBase64String(buffer));
        }

        public Task<int> GetRefreshTokenLifetimeInMinutes()
        {
            return Task.FromResult(settings.Value.RefreshTokenSettings.LifeTimeInMinutes);
        }

        public Task<string?> GetUserIdFromToken(string token)
        {
            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false, // we may be trying to validate an expired token so it makes no sense checking for it's lifetime.
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = settings.Value.AccessTokenSettings.Issuer,
                    ValidAudience = settings.Value.AccessTokenSettings.Audience,
                    IssuerSigningKey = rsaSecurityKey,
                    ClockSkew = TimeSpan.FromMinutes(0)
                };

                var jwtHandler = new JwtSecurityTokenHandler();
                var claims = jwtHandler.ValidateToken(token, tokenValidationParameters, out _);
                var userId = claims.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString();

                return Task.FromResult(userId);
            }
            catch (Exception ex)
            {
                throw new InvalidTokenException(ex.Message, ex);
            }
        }

        public Task<bool> IsTokenValid(string token, bool validateLifeTime)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = validateLifeTime,
                ValidateIssuerSigningKey = true,
                ValidIssuer = settings.Value.AccessTokenSettings.Issuer,
                ValidAudience = settings.Value.AccessTokenSettings.Audience,
                IssuerSigningKey = rsaSecurityKey,
                ClockSkew = TimeSpan.FromMinutes(0)
            };

            var jwtHandler = new JwtSecurityTokenHandler();
            try
            {
                jwtHandler.ValidateToken(token, tokenValidationParameters, out _);
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
    }
}
