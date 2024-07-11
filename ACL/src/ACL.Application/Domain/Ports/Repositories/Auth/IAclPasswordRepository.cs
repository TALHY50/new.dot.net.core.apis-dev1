using Notification.Application.Contracts.Requests;
using Notification.Application.Contracts.Response;

namespace ACL.Application.Domain.Ports.Repositories.Auth
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
