using SharedKernel.Main.ACL.Contracts.Requests;
using SharedKernel.Main.ACL.Contracts.Responses;

namespace SharedKernel.Main.ACL.Application.Interfaces.Repositories
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
