using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Application.Interfaces.Services;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using Microsoft.Extensions.Logging;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Exceptions;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Business.Application.Features.Auth
{ 
    public class RefreshToken : IRefreshTokenUseCase
    {
        private readonly ILogger _logger;
        private readonly IAuthToken _authToken;
        private readonly IUserRepository _authRepository; 
        public RefreshToken(
            ILogger<RefreshToken> logger,
            IAuthToken authToken,
            IUserRepository authRepository)
        {
            this._logger = logger;
            this._authToken = authToken;
            this._authRepository = authRepository;
        }
        public async Task<RefreshTokenResponse> Execute(RefreshTokenRequest request)
        {
            try
            {
                if (!await this._authToken.IsTokenValid(request.AccessToken, false))
                {
                    return new RefreshTokenErrorResponse
                    {
                        Message = Enum.GetName(ErrorCodes.AccessTokenIsNotValid),
                        Code = ErrorCodes.AccessTokenIsNotValid.ToString("D")
                    };
                }
                var userIdString = await this._authToken.GetUserIdFromToken(request.AccessToken);
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
                string nameIdentifier = user.Id.ToString();
                var claim = user.Claims.SingleOrDefault(c => c.Type == "scope");
                string? scope = null;
                if (claim != null)
                {
                    scope = string.Join(" ", claim.Value);
                }
                var newToken = await this._authToken.GenerateAccessToken(nameIdentifier, scope);
                user.RefreshToken.Value = await this._authToken.GenerateRefreshToken();
                user.RefreshToken.Active = true;
                user.RefreshToken.ExpirationDate = DateTime.UtcNow.AddMinutes(await this._authToken.GetRefreshTokenLifetimeInMinutes());
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
