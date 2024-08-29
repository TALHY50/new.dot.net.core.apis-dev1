using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;

namespace ACL.App.Domain.Services
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
