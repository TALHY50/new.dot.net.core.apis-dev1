using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;

namespace ACL.Business.Application.Interfaces.Repositories
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
