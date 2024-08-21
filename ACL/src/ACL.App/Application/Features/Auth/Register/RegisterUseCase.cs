﻿using ACL.App.Application.Common.Enums;
using ACL.App.Application.Features.Auth.Register.Request;
using ACL.App.Application.Features.Auth.Register.Response;
using ACL.App.Application.Interfaces.Repositories.Auth;
using ACL.App.Application.Interfaces.Services.Cryptography;
using ACL.App.Application.Interfaces.Services.Token;
using SharedKernel.Main.Domain.ACL.Domain.Auth;
using Claim = SharedKernel.Main.Domain.ACL.Domain.Auth.Claim;

namespace ACL.App.Application.Features.Auth.Register
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
                    Password = this._cryptographyService.HashPassword(request.Password, salt),
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