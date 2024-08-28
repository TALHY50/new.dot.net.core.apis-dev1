using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;

namespace ACL.App.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IPasswordRepository
    {
        /// <inheritdoc/>
        Task<ScopeResponse> Reset(AclPasswordResetRequest request);
        /// <inheritdoc/>
        ScopeResponse Forget(AclForgetPasswordRequest request);
        /// <inheritdoc/>
        Task<ScopeResponse> VerifyToken(AclForgetPasswordTokenVerifyRequest request);
    }
}
