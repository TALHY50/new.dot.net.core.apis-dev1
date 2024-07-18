using App.Contracts.Requests;
using App.Contracts.Response;

namespace App.Domain.Ports.Repositories.Auth
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
