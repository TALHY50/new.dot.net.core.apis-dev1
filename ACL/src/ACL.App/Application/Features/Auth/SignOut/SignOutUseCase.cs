using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Application.Interfaces.Services;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;
using SharedKernel.Main.Application.Common.Enums;

namespace ACL.Web.Application.Features.Auth.SignOut
{
    /// <inheritdoc/>
    public class SignOutUseCase : ISignOutUseCase
    {
        private readonly ILogger _logger;
        private readonly IUserRepository _authRepository;
        /// <inheritdoc/>
        public SignOutUseCase(
            ILogger<SignOutUseCase> logger,
            IUserRepository authRepository)
        {
            _logger = logger;
            _authRepository = authRepository;
        }
        /// <inheritdoc/>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning disable CS8601 // Async method lacks 'await' operators and will run synchronously
        public async Task<SignOutResponse> Execute(SignOutRequest request)
        {
            try
            {
                var user = _authRepository.FindByIdAsync(request.UserId);
                if (user == null)
                {
                    return new SignOutErrorResponse
                    {
                        Message = Enum.GetName(ErrorCodes.UserDoesNotExist),
                        Code = ErrorCodes.UserDoesNotExist.ToString("D")
                    };
                }
                user.RefreshToken.Active = false;
                _authRepository.UpdateAndSaveAsync(user);

                return new SignOutSuccessResponse
                {
                    Message = $"User signed out at {DateTime.UtcNow} server time."
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new SignOutErrorResponse
                {
                    Code = "Some Error Code",
                    Message = "Some Error Message"
                };
            }
        }
    }
}
