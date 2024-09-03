using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ACL.Business.Application.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SharedKernel.Main.Application.Exceptions;

namespace ACL.Business.Infrastructure.Jwt
{
    public class Jwt(IOptions<JwtSettings> settings, RsaSecurityKey rsaSecurityKey)
        : IIdentity
    {
        public static readonly string VersionClaimType = "ver";

        public Task<string> GenerateAccessToken(string nameIdentifier, string? scope)
        {
            var signingCredentials = new SigningCredentials(
                key: rsaSecurityKey,
                algorithm: SecurityAlgorithms.RsaSha256
            );

            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, nameIdentifier));
            if (scope != null)
            {
                claimsIdentity.AddClaim(new System.Security.Claims.Claim("scope", scope));
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

        public Task<string> GenerateIdToken(string nameIdentifier, string name, string email, string givenName,
            string surName)
        {
            var signingCredentials = new SigningCredentials(
                key: rsaSecurityKey,
                algorithm: SecurityAlgorithms.RsaSha256
            );
            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, nameIdentifier));
            claimsIdentity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.Name, name));
            claimsIdentity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.Email, email));
            claimsIdentity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.GivenName, givenName));
            claimsIdentity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.Surname, surName));
            /*// Add custom claims if any
            foreach (var c in user?.Claims ?? System.Linq.Enumerable.Empty<Claim>())
            {
                claimsIdentity.AddClaim(new System.Security.Claims.Claim(c.Type, c.Value));
            }*/
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
            using var rng = RandomNumberGenerator.Create();
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
                    ValidateLifetime = false,
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

        public string GenerateJwtTokenWithSymmetricKey(string nameIdentifier, string keyId, string secretKey, string requestData, int seconds)
        {
            string hash = ComputeSha256Hash(requestData);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials)
            {
                { "kid", keyId }
            };
            var data = JsonConvert.SerializeObject(new PayloadData(hash));
            var jwtPayload = new JwtPayload
            {
                { "nameid", nameIdentifier},
                { "data", data },
                { "iat", DateTimeOffset.UtcNow.ToUnixTimeSeconds() },
                { "exp", DateTimeOffset.UtcNow.AddSeconds(seconds).ToUnixTimeSeconds() }
            };
            var token = new JwtSecurityToken(header, jwtPayload);
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        } 
        public bool ValidateJwtTokenWithSymmetricKey(string token, string secretKey, string requestData) 
        { 
            var tokenHandler = new JwtSecurityTokenHandler(); 
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                ClockSkew = TimeSpan.Zero // Optional: set to zero for precise expiration check
            }; 
            var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            var jwtToken = validatedToken as JwtSecurityToken;
            var dataStr = principal.Claims.FirstOrDefault(x => x.Type == "data")?.Value ?? null;
            if (dataStr == null) 
                throw new SecurityTokenMalformedException("Payload is empty or missing");
            dynamic dataJson = (object)dataStr;
            PayloadData? payloadData = JsonConvert.DeserializeObject<PayloadData>(dataStr);
            var hash = payloadData.SHA256; 
            if (string.IsNullOrWhiteSpace(hash))
                    throw new SecurityTokenMalformedException("Hash is missing"); 
            var expectedHash = ComputeSha256Hash(requestData);
            if (hash != expectedHash) 
                throw new SecurityTokenException("Hash mismatched");
            return hash == expectedHash; 
        }

        public string GetNameId(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(token))
            {
                throw new ArgumentException("Invalid JWT token.");
            }

            var jwtTokenObj = handler.ReadJwtToken(token);
            var nameId = jwtTokenObj.Claims.FirstOrDefault(c => c.Type == "nameid")?.Value;

            return nameId;
        }

        private string ComputeSha256Hash(string payload)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(payload));
                StringBuilder builder = new StringBuilder();
                foreach (var @byte in bytes)
                {
                    builder.Append(@byte.ToString("x2"));
                }

                return builder.ToString();
            }
        } 
    }


    public class PayloadData
    {
        public string SHA256 { get; set; }
        public PayloadData(string hash)
        {
            this.SHA256 = hash;
        }
        
    } 
}

    
    
