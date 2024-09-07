using ACL.Business.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Claim = System.Security.Claims.Claim;

namespace ACL.Business.Application.Interfaces.Services
{
    public class CustomTokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public CustomTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<string> GenerateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"]);

            var claims = new[]
                  {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // Ensure user.Id is string
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims), // Pass claims into ClaimsIdentity
                Expires = DateTime.UtcNow.AddMinutes(30), // Set expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Task.FromResult(tokenHandler.WriteToken(token));
        }

        public Task<string> GenerateRefreshToken()
        {
            // Generate a refresh token (can be random or using custom logic)
            var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            return Task.FromResult(refreshToken);
        }
    }
}