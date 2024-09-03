using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using Ardalis.SharedKernel;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IPasswordRepository : IRepository<User>, IExtendedRepositoryBase<User>
    {
        /// <inheritdoc/>
        Task<ScopeResponse> Reset(AclPasswordResetRequest request);
        /// <inheritdoc/>
        ScopeResponse Forget(AclForgetPasswordRequest request);
        /// <inheritdoc/>
        Task<ScopeResponse> VerifyToken(AclForgetPasswordTokenVerifyRequest request);
    }
}
