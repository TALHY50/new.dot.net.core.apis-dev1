using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Application.Interfaces.Services;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using Microsoft.Extensions.Logging;
using SharedKernel.Main.Application.Enums;

namespace ACL.Business.Application.Features.Auth
{
    /// <inheritdoc/>
    public class SignOut : ISignOutUseCase
    {
        private readonly ILogger _logger;
        private readonly IUserRepository _authRepository;
        /// <inheritdoc/>
        public SignOut(
            ILogger<SignOut> logger,
            IUserRepository authRepository)
        {
            this._logger = logger;
            this._authRepository = authRepository;
        }
        /// <inheritdoc/>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning disable CS8601 // Async method lacks 'await' operators and will run synchronously
        public async Task<SignOutResponse> Execute(SignOutRequest request)
        {
            try
            {
                var user = this._authRepository.FindByIdAsync(request.UserId);
                if (user == null)
                {
                    return new SignOutErrorResponse
                    {
                        Message = Enum.GetName(ErrorCodes.UserDoesNotExist),
                        Code = ErrorCodes.UserDoesNotExist.ToString("D")
                    };
                }
                user.RefreshToken.Active = false;
                this._authRepository.UpdateAndSaveAsync(user);

                return new SignOutSuccessResponse
                {
                    Message = $"User signed out at {DateTime.UtcNow} server time."
                };
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);
                return new SignOutErrorResponse
                {
                    Code = "Some Error Code",
                    Message = "Some Error Message"
                };
            }
        }
    }
}
