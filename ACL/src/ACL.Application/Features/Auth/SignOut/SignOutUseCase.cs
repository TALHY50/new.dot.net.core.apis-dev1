using ACL.Application.Common.Enums;
using ACL.Application.Domain.Ports.Repositories.Auth;
using ACL.Application.Features.Auth.SignOut.Request;
using ACL.Application.Features.Auth.SignOut.Response;
using Microsoft.Extensions.Logging;

namespace ACL.Application.Features.Auth.SignOut
{
    /// <inheritdoc/>
    public class SignOutUseCase : ISignOutUseCase
    {
        private readonly ILogger _logger;
        private readonly IAclUserRepository _authRepository;
        /// <inheritdoc/>
        public SignOutUseCase(
            ILogger<SignOutUseCase> logger,
            IAclUserRepository authRepository)
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
