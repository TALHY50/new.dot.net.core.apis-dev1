using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;

namespace ACL.App.Application.Interfaces.Repositories.Auth
{
    /// <inheritdoc/>
    public interface IAclPasswordRepository
    {
        /// <inheritdoc/>
        Task<AclResponse> Reset(AclPasswordResetRequest request);
        /// <inheritdoc/>
        AclResponse Forget(AclForgetPasswordRequest request);
        /// <inheritdoc/>
        Task<AclResponse> VerifyToken(AclForgetPasswordTokenVerifyRequest request);
    }
}
