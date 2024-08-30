using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;

namespace ACL.Bussiness.Domain.Services
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
