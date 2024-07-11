using Notification.Application.Common.Enums;
using Notification.Application.Domain.Auth;
using Notification.Application.Domain.Ports.Repositories.Auth;
using Notification.Application.Domain.Ports.Services.Cryptography;
using Notification.Application.Domain.Ports.Services.Token;
using Notification.Application.Features.Auth.Register.Request;
using Notification.Application.Features.Auth.Register.Response;
using Microsoft.Extensions.Logging;
using Claim = ACL.Application.Domain.Auth.Claim;

namespace ACL.Application.Features.Auth.Register
{
    /// <inheritdoc/>
    public class RegisterUseCase : IRegisterUseCase
    {
        private readonly ILogger _logger;
        private readonly IAuthTokenService _authTokenService;
        private readonly IAclUserRepository _authRepository;
        private readonly ICryptographyService _cryptographyService;
/// <inheritdoc/>
        public RegisterUseCase(
            ILogger<RegisterUseCase> logger,
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
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning disable CS8601 // Async method lacks 'await' operators and will run synchronously
        public async Task<RegisterResponse> Execute(RegisterRequest request)
        {
            try
            {
                var user =  this._authRepository.FindByEmail(request.Email);
                if (user != null)
                {
                    var response = new RegisterErrorResponse
                    {
                        Message = Enum.GetName(ErrorCodes.UserWithEmailAlreadyExist),
                        Code = ErrorCodes.UserWithEmailAlreadyExist.ToString("D")
                    };
                    return response;
                }

                var salt = this._cryptographyService.GenerateSalt();
                var currentDate = DateTime.UtcNow;

                user = new AclUser()
                {
                    Status = 1,
                    Email = request.Email,
                    Password = _cryptographyService.HashPassword(request.Password, salt),
                    Salt = salt,
                    FirstName = request.Name,
                    LastName = request.LastName,
                    Claims = ToClaims(request.Claims),
                    CreatedAt = currentDate,
                    UpdatedAt = currentDate
                };

                 this._authRepository.AddAndSaveAsync(user);

                return new RegisterSuccessResponse
                {
                    UserId = user.Id
                };
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);

                var response = new RegisterErrorResponse
                {
                    Message = Enum.GetName(ErrorCodes.AnUnexpectedErrorOccurred),
                    Code = ErrorCodes.AnUnexpectedErrorOccurred.ToString("D")
                };

                return response;
            }
        }

        private static IList<Claim>? ToClaims(IList<Claim> requestClaims)
        {
            if (requestClaims == null) return null;
            var claims = new List<Claim>();
            claims.AddRange(requestClaims.Select(r => new Claim { Type = r.Type, Value = r.Value }).ToList());
            return claims;
        }
    }
}