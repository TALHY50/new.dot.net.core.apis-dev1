using ACL.Business.Contracts.Responses;
using ACL.Business.Infrastructure.Jwt;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Claim = System.Security.Claims.Claim;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ACL.Business.Application.Features.Auth
{


    public record LoginCommand(string Email, string Password) : IRequest<LoginResultDto>;


    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            /*RuleFor(x => x.app_id).NotEmpty().WithMessage("App Id should not be empty!").WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
            RuleFor(x => x.app_secret).NotEmpty().WithMessage("App Secret should not be empty!").WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());*/
        }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResultDto>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly JwtSettings _jwtSettings;
        private readonly RsaSecurityKey _rsaKey;

        public LoginCommandHandler(
            IAuthenticationService authenticationService,
            IOptions<JwtSettings> jwtSettings,
            RsaSecurityKey rsaKey)
        {
            _authenticationService = authenticationService;
            _jwtSettings = jwtSettings.Value;
            _rsaKey = rsaKey;
        }

        public async Task<LoginResultDto> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            // Authenticate the user using your custom authentication service
            var result = await PasswordLogInAsync(command.Email, command.Password);

            if (!result.Succeeded)
            {
                throw new UnauthorizedAccessException("Login failed: invalid email or password.");
            }

            // Generate JWT token based on the existing RSA key
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Email, command.Email),
                new Claim(ClaimTypes.Name, command.Email),
                // Add more claims as necessary
            }),
                Expires = DateTime.UtcNow.AddSeconds(_jwtSettings.AccessTokenSettings.LifeTimeInSeconds),
                Issuer = _jwtSettings.AccessTokenSettings.Issuer,
                Audience = _jwtSettings.AccessTokenSettings.Audience,
                SigningCredentials = new SigningCredentials(_rsaKey, SecurityAlgorithms.RsaSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);

            // Generate refresh token (if needed)
            var refreshToken = GenerateRefreshToken();

            return new LoginResultDto
            {
                token_type = "Bearer",
                access_token = accessToken,
                expires_in = _jwtSettings.AccessTokenSettings.LifeTimeInSeconds,
                refresh_token = refreshToken
            };
        }

        public async Task<SignInResult> PasswordLogInAsync(string userName, string password)
        {
            // Hardcoded credentials for testing
            var staticUserName = "testuser@example.com";
            var staticPassword = "TestPassword123";

            // Simulate a delay for asynchronous operation
            await Task.Delay(100);

            if (userName == staticUserName && password == staticPassword)
            {
                return SignInResult.Success;
            }
            return SignInResult.Failed;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}