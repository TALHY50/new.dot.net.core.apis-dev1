using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;

namespace ACL.Application.Interfaces.Repositories.V1
{
    /// <inheritdoc/>
    public interface IAclPasswordRepository
    {
        /// <inheritdoc/>
        AclResponse Reset(AclPasswordResetRequest request);
        /// <inheritdoc/>
        AclResponse Forget(AclForgetPasswordRequest request);
        /// <inheritdoc/>
        AclResponse VerifyToken(AclForgetPasswordTokenVerifyRequest request);
    }
}
