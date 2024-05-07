using ACL.Application.Enums;
using ACL.Application.Ports.Repositories;
using ACL.Application.Ports.Services;
using ACL.Application.UseCases.CreateUser.Request;
using ACL.Application.UseCases.CreateUser.Response;
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using Claim = ACL.Application.UseCases.CreateUser.Request.Claim;

namespace ACL.Application.UseCases.CreateUser
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly ILogger _logger;
        private readonly IAuthTokenService _authTokenService;
        private readonly IAclUserRepository _authRepository;
        private readonly ICryptographyService _cryptographyService;

        public CreateUserUseCase(
            ILogger<CreateUserUseCase> logger,
            IAuthTokenService authTokenService,
            IAclUserRepository authRepository,
            ICryptographyService cryptographyService)
        {
            this._logger = logger;
            this._authTokenService = authTokenService;
            this._authRepository = authRepository;
            this._cryptographyService = cryptographyService;
        }

        public async Task<CreateUserResponse> Execute(CreateUserRequest request)
        {
            try
            {
                var salt = this._cryptographyService.GenerateSalt();
                var currentDate = DateTime.UtcNow;

                var user = new AclUser()
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

                await this._authRepository.AddAndSaveAsync(user);

                return new CreateUserSuccessResponse
                {
                    UserId = user.Id
                };
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);

                var response = new CreateUserErrorResponse
                {
                    Message = Enum.GetName(ErrorCodes.AnUnexpectedErrorOcurred),
                    Code = ErrorCodes.AnUnexpectedErrorOcurred.ToString("D")
                };

                return response;
            }
        }

        private static IList<Domain.Claim> ToClaims(IList<Request.Claim> requestClaims)
        {
            if (requestClaims == null) return null;
            var claims = new List<Domain.Claim>();
            claims.AddRange(requestClaims.Select(r => new Domain.Claim { Type = r.Type, Value = r.Value }).ToList());
            return claims;
        }
    }
}
