using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IPasswordRepository
    {
        /// <inheritdoc/>
        Task<ApplicationResponse> Reset(AclPasswordResetRequest request);
        /// <inheritdoc/>
        ApplicationResponse Forget(AclForgetPasswordRequest request);
        /// <inheritdoc/>
        Task<ApplicationResponse> VerifyToken(AclForgetPasswordTokenVerifyRequest request);
    }
}
