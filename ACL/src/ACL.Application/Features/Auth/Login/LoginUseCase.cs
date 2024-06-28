using ACL.Application.Common.Enums;
using ACL.Application.Domain.Auth;
using ACL.Application.Domain.Ports.Repositories.Auth;
using ACL.Application.Domain.Ports.Services.Cryptography;
using ACL.Application.Domain.Ports.Services.Token;
using ACL.Application.Features.Auth.Login.Request;
using ACL.Application.Features.Auth.Login.Response;
using Microsoft.Extensions.Logging;

namespace ACL.Application.Features.Auth.Login
{
    /// <inheritdoc/>
    public class LoginUseCase : ILoginUseCase
    {
        private readonly ILogger _logger;
        private readonly IAuthTokenService _authTokenService;
        private readonly IAclUserRepository _authRepository;
        private readonly ICryptographyService _cryptographyService;
        /// <inheritdoc/>
        public LoginUseCase(
            ILogger<LoginUseCase> logger,
            IAuthTokenService authTokenService,
            IAclUserRepository authRepository,
            ICryptographyService cryptographyService)
        {
            this._logger = logger;
            this._authTokenService = authTokenService;
            this._authRepository = authRepository;
            this._cryptographyService = cryptographyService;
        }
        /// <inheritdoc/>
        public async Task<LoginResponse> Execute(LoginRequest request)
        {
            try
            {
                var user = this._authRepository.FindByEmail(request.Email);
                if (user == null)
                {
                    var response = new LoginErrorResponse
                    {
#pragma warning disable CS8601 // Possible null reference argument.
                        Message = Enum.GetName(ErrorCodes.UserDoesNotExist),
                        Code = ErrorCodes.UserDoesNotExist.ToString("D")
                    };
                    return response;
                }

                if (AreCredentialsValid(request.Password, user))
                {
                    user.RefreshToken = new Domain.Auth.RefreshToken
                    {
                        Value = await this._authTokenService.GenerateRefreshToken(),
                        Active = true,
                        ExpirationDate = DateTime.UtcNow.AddMinutes(await this._authTokenService.GetRefreshTokenLifetimeInMinutes())
                    };
                     this._authRepository.UpdateAndSaveAsync(user);

                    var idToken = await this._authTokenService.GenerateIdToken(user);
                    var accessToken = await this._authTokenService.GenerateAccessToken(user);

                    var response = new LoginSuccessResponse
                    {
                        IdToken = idToken,
                        AccessToken = accessToken,
                        RefreshToken = user.RefreshToken.Value
                    };

                    return response;
                }
                else
                {
                    var response = new LoginErrorResponse
                    {
                        Message = Enum.GetName(ErrorCodes.CredentialsAreNotValid),
                        Code = ErrorCodes.CredentialsAreNotValid.ToString("D")
                    };

                    return response;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);

                var response = new LoginErrorResponse
                {

                    Message = Enum.GetName(ErrorCodes.AnUnexpectedErrorOccurred),
                    Code = ErrorCodes.AnUnexpectedErrorOccurred.ToString("D")
                };

                return response;
            }
        }

        private bool AreCredentialsValid(string testPassword, AclUser user)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var hash = this._cryptographyService.HashPassword(testPassword, user.Salt);
            return hash == user.Password;
        }
    }
}
