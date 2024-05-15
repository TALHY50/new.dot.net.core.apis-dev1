using ACL.Application.Enums;
using ACL.Application.Ports.Repositories;
using ACL.Application.Ports.Services;
using ACL.Application.UseCases.CreateUser.Request;
using ACL.Application.UseCases.CreateUser.Response;
using ACL.Core.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests.V1;
using ACL.Response.V1;
using Claim = ACL.Application.UseCases.CreateUser.Request.Claim;

namespace ACL.Application.UseCases.CreateUser
{
    public class RegisterUseCase : IRegisterUseCase
    {
        private readonly ILogger _logger;
        private readonly IAuthTokenService _authTokenService;
        private readonly IAclUserRepository _authRepository;
        private readonly ICryptographyService _cryptographyService;

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

        public async Task<RegisterResponse> Execute(RegisterRequest request)
        {
            try
            {
                var salt = this._cryptographyService.GenerateSalt();
                var currentDate = DateTime.UtcNow;
                AclUserRequest userRequest = new AclUserRequest
                {
                    Email = request.Email,
                    FirstName = request.Name,
                    LastName = request.LastName,
                    Language = "en-US",
                    Avatar = "Should be image as base 64",
                    Password = _cryptographyService.HashPassword(request.Password, salt),
                    Salt = salt,
                    DOB = currentDate,
                    Gender = 1,
                    Address = "Pantho path Dhaka",
                    City = "Dhaka",
                    Country = 1,
                    Phone = "+88014314xxxxx",
                    UserName = request.Name,
                    ImgPath = "Should be base64",
                    Status = 1,
                    UserGroup = new ulong[] { 1, 2 },
                    Claims = ToClaims(request.Claims)
                };
                AclResponse result = await _authRepository.AddUser(userRequest);
                AclUser user = (AclUser)result.Data;

                return new RegisterSuccessResponse
                {
                    UserId = user.Id,
                    //User = user
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

        private static IList<Core.Models.Claim> ToClaims(IList<Core.Models.Claim> requestClaims)
        {
            if (requestClaims == null) return null;
            var claims = new List<Core.Models.Claim>();
            claims.AddRange(requestClaims.Select(r => new Core.Models.Claim { Type = r.Type, Value = r.Value }).ToList());
            return claims;
        }
    }
}
