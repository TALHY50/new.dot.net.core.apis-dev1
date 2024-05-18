using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;

namespace ACL.Application.Interfaces.Repositories.V1
{
    /// <inheritdoc/>
    public interface IAclPasswordRepository
    {
        /// <inheritdoc/>
        Task<AclResponse> Reset(AclPasswordResetRequest request);
        /// <inheritdoc/>
        Task<AclResponse> Forget(AclForgetPasswordRequest request);
        /// <inheritdoc/>
        Task<AclResponse> VerifyToken(AclForgetPasswordTokenVerifyRequest request);
    }
}
