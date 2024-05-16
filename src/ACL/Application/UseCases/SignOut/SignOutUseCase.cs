using ACL.Application.Ports.Repositories;
using ACL.Application.UseCases.SignOut.Request;
using ACL.Application.UseCases.SignOut.Response;
using ACL.UseCases.Enums;

namespace ACL.Application.UseCases.SignOut
{
    public class SignOutUseCase : ISignOutUseCase
    {
        private readonly ILogger _logger;
        private readonly IAclUserRepository _authRepository;

        public SignOutUseCase(
            ILogger<SignOutUseCase> logger,
            IAclUserRepository authRepository)
        {
            this._logger = logger;
            this._authRepository = authRepository;
        }

        public async Task<SignOutResponse> Execute(SignOutRequest request)
        {
            try
            {
                var user = await this._authRepository.FindByIdAsync(request.UserId);
                if (user == null)
                {
                    return new SignOutErrorResponse
                    {
                        Message = Enum.GetName(ErrorCodes.UserDoesNotExist),
                        Code = ErrorCodes.UserDoesNotExist.ToString("D")
                    };
                }
                user.RefreshToken.Active = false;
                await this._authRepository.UpdateAndSaveAsync(user);

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
