using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Application.Interfaces.Services;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using Microsoft.Extensions.Logging;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Business.Application.Features.Auth
{
    public class Login : ILoginUseCase
    {
        private readonly ILogger _logger;
        private readonly IAuthToken _authToken;
        private readonly IUserRepository _authRepository;
        private readonly ICryptography _cryptography;
       
        public Login(
            ILogger<Login> logger,
            IAuthToken authToken,
            IUserRepository authRepository,
            ICryptography cryptography)
        {
            this._logger = logger;
            this._authToken = authToken;
            this._authRepository = authRepository;
            this._cryptography = cryptography;
        }
        public async Task<LoginResponse> Execute(LoginRequest request)
        {
            try
            {
                var user = this._authRepository.FindByEmail(request.Email);
                if (user == null)
                {
                    var response = new LoginErrorResponse
                    {
                        Message = Enum.GetName(ErrorCodes.UserDoesNotExist) ?? throw new InvalidOperationException(),
                        Code = ErrorCodes.UserDoesNotExist.ToString("D")
                    };
                    return response;
                }

                if (AreCredentialsValid(request.Password, user))
                {
                    user.RefreshToken = new ACL.Business.Domain.Entities.RefreshToken
                    {
                        Value = await this._authToken.GenerateRefreshToken(),
                        Active = true,
                        ExpirationDate = DateTime.UtcNow.AddMinutes(await this._authToken.GetRefreshTokenLifetimeInMinutes())
                    };
                     this._authRepository.UpdateAndSaveAsync(user);

                    var idToken = await this._authToken.GenerateIdToken(user);
                    var accessToken = await this._authToken.GenerateAccessToken(user);

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

        private bool AreCredentialsValid(string testPassword, User user)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var hash = this._cryptography.HashPassword(testPassword, user.Salt);
            return hash == user.Password;
        }
    }
}
