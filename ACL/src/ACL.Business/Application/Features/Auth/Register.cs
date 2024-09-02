using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Application.Interfaces.Services;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using Microsoft.Extensions.Logging;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using Claim = ACL.Business.Domain.Entities.Claim;

namespace ACL.Business.Application.Features.Auth
{
    /// <inheritdoc/>
    public class Register : IRegisterUseCase
    {
        private readonly ILogger _logger;
        private readonly IAuthToken _authToken;
        private readonly IUserRepository _authRepository;
        private readonly ICryptography _cryptography;
/// <inheritdoc/>
        public Register(
            ILogger<Register> logger,
            IAuthToken authToken,
            IUserRepository authRepository,
            ICryptography cryptography)
        {
            this._logger = logger;
            this._authToken = authToken;
            this._authRepository = authRepository;
            this._cryptography = cryptography;
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

                var salt = this._cryptography.GenerateSalt();
                var currentDate = DateTime.UtcNow;

                user = new User()
                {
                    Status = 1,
                    Email = request.Email,
                    Password = this._cryptography.HashPassword(request.Password, salt),
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