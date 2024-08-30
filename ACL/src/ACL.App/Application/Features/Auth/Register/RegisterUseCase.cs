using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Application.Interfaces.Services;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;
using ACL.Bussiness.Domain.Entities;
using SharedKernel.Main.Application.Common.Enums;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using Claim = ACL.Bussiness.Domain.Entities.Claim;

namespace ACL.Web.Application.Features.Auth.Register
{
    /// <inheritdoc/>
    public class RegisterUseCase : IRegisterUseCase
    {
        private readonly ILogger _logger;
        private readonly IAuthTokenService _authTokenService;
        private readonly IUserRepository _authRepository;
        private readonly ICryptographyService _cryptographyService;
        /// <inheritdoc/>
        public RegisterUseCase(
            ILogger<RegisterUseCase> logger,
            IAuthTokenService authTokenService,
            IUserRepository authRepository,
            ICryptographyService cryptographyService)
        {
            _logger = logger;
            _authTokenService = authTokenService;
            _authRepository = authRepository;
            _cryptographyService = cryptographyService;
        }
        /// <inheritdoc/>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning disable CS8601 // Async method lacks 'await' operators and will run synchronously
        public async Task<RegisterResponse> Execute(RegisterRequest request)
        {
            try
            {
                var user = _authRepository.FindByEmail(request.Email);
                if (user != null)
                {
                    var response = new RegisterErrorResponse
                    {
                        Message = Enum.GetName(ErrorCodes.UserWithEmailAlreadyExist),
                        Code = ErrorCodes.UserWithEmailAlreadyExist.ToString("D")
                    };
                    return response;
                }

                var salt = _cryptographyService.GenerateSalt();
                var currentDate = DateTime.UtcNow;

                user = new User()
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

                _authRepository.AddAndSaveAsync(user);

                return new RegisterSuccessResponse
                {
                    UserId = user.Id
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

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