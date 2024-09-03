using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;

namespace ACL.Business.Domain.Services
{
    /// <inheritdoc/>
    public interface IBranchService : IBranchRepository
    {
        /// <inheritdoc/>
        ScopeResponse Get();
        /// <inheritdoc/>
        ScopeResponse Add(AclBranchRequest request);
        /// <inheritdoc/>
        ScopeResponse Edit(ulong id, AclBranchRequest request);
        /// <inheritdoc/>
        ScopeResponse Find(ulong id);
        /// <inheritdoc/>
        new ScopeResponse Delete(ulong id);
    }
}
