using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;

namespace ACL.Bussiness.Application.Interfaces.Repositories
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
