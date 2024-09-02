using ACL.Business.Application.Behaviours;
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
        private readonly IIdentity _identity;
        private readonly IUserRepository _authRepository;
        private readonly ICryptography _cryptography;
       
        public Login(
            ILogger<Login> logger,
            IIdentity identity,
            IUserRepository authRepository,
            ICryptography cryptography)
        {
            this._logger = logger;
            this._identity = identity;
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
                        Value = await this._identity.GenerateRefreshToken(),
                        Active = true,
                        ExpirationDate = DateTime.UtcNow.AddMinutes(await this._identity.GetRefreshTokenLifetimeInMinutes())
                    };
                     this._authRepository.UpdateAndSaveAsync(user);
                     string nameIdentifier = user.Id.ToString();
                     var claim = user.Claims.SingleOrDefault(c => c.Type == "scope");
                     string? scope = null;
                     if (claim != null)
                     {
                          scope = string.Join(" ", claim.Value);
                     }

                     string name = user?.FirstName ?? "";
                     string email = user?.FirstName ?? "";
                     string givenName = user?.LastName ?? "";
                     string surName = user?.LastName ?? "";
                    var idToken = await this._identity.GenerateIdToken( nameIdentifier,  name,  email,  givenName,  surName);
                    var accessToken = await this._identity.GenerateAccessToken(nameIdentifier, scope);

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
            var hash = this._cryptography.HashPassword(testPassword, user.Salt);
            return hash == user.Password;
        }
    }
}
