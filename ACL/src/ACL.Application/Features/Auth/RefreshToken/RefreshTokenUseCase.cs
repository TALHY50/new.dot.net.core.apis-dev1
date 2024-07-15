using ACL.Application.Common.Enums;
using ACL.Application.Common.Exceptions;
using ACL.Application.Domain.Ports.Repositories.Auth;
using ACL.Application.Domain.Ports.Services.Token;
using ACL.Application.Features.Auth.RefreshToken.Request;
using ACL.Application.Features.Auth.RefreshToken.Response;
using Microsoft.Extensions.Logging;

namespace ACL.Application.Features.Auth.RefreshToken
{
    /// <inheritdoc/>
    public class RefreshTokenUseCase : IRefreshTokenUseCase
    {
        private readonly ILogger _logger;
        private readonly IAuthTokenService _authTokenService;
        private readonly IAclUserRepository _authRepository;
        /// <inheritdoc/>
        public RefreshTokenUseCase(
            ILogger<RefreshTokenUseCase> logger,
            IAuthTokenService authTokenService,
            IAclUserRepository authRepository)
        {
            this._logger = logger;
            this._authTokenService = authTokenService;
            this._authRepository = authRepository;
        }
        /// <inheritdoc/>
        public async Task<RefreshTokenResponse> Execute(RefreshTokenRequest request)
        {
            try
            {
                if (!await this._authTokenService.IsTokenValid(request.AccessToken, false))
                {
                    return new RefreshTokenErrorResponse
                    {
#pragma warning disable CS8601 // Possible null reference argument.
                        Message = Enum.GetName(ErrorCodes.AccessTokenIsNotValid),
                        Code = ErrorCodes.AccessTokenIsNotValid.ToString("D")
                    };
                }

                var userIdString = await this._authTokenService.GetUserIdFromToken(request.AccessToken);
                var userId = Convert.ToUInt32(userIdString);
                var user =  this._authRepository.FindByIdAsync(userId);

                if (user != null && !user.RefreshToken.Active)
                {
                    return new RefreshTokenErrorResponse
                    {
                        Message = Enum.GetName(ErrorCodes.RefreshTokenIsNotActive),
                        Code = ErrorCodes.RefreshTokenIsNotActive.ToString("D")
                    };
                }

                if (user != null && user.RefreshToken.ExpirationDate < DateTime.UtcNow)
                {
                    return new RefreshTokenErrorResponse
                    {
                        Message = Enum.GetName(ErrorCodes.RefreshTokenHasExpired),
                        Code = ErrorCodes.RefreshTokenHasExpired.ToString("D")
                    };
                }

                if (user != null && user.RefreshToken.Value != request.RefreshToken)
                {
                    return new RefreshTokenErrorResponse
                    {
                        Message = Enum.GetName(ErrorCodes.RefreshTokenIsNotCorrect),
                        Code = ErrorCodes.RefreshTokenIsNotCorrect.ToString("D")
                    };
                }
#pragma warning disable CS8604 // Possible null reference argument.
                var newToken = await this._authTokenService.GenerateAccessToken(user);

                user.RefreshToken.Value = await this._authTokenService.GenerateRefreshToken();
                user.RefreshToken.Active = true;
                user.RefreshToken.ExpirationDate = DateTime.UtcNow.AddMinutes(await this._authTokenService.GetRefreshTokenLifetimeInMinutes());
                 this._authRepository.UpdateAndSaveAsync(user);

                var response = new RefreshTokenSuccessResponse
                {
                    AccessToken = newToken,
                    RefreshToken = user.RefreshToken.Value,
                    RefreshTokenExpirationDate = user.RefreshToken.ExpirationDate
                };

                return response;
            }
            catch (InvalidTokenException ex)
            {
                this._logger.LogError(ex, ex.Message);

                var response = new RefreshTokenErrorResponse
                {
                    Message = Enum.GetName(ErrorCodes.AccessTokenIsNotValid),
                    Code = ErrorCodes.AccessTokenIsNotValid.ToString("D")
                };

                return response;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);

                var response = new RefreshTokenErrorResponse
                {
                    Message = Enum.GetName(ErrorCodes.AnUnexpectedErrorOccurred),
                    Code = ErrorCodes.AnUnexpectedErrorOccurred.ToString("D")
                };

                return response;
            }
        }
    }
}
