using SharedKernel.Main.ACL.Application.Interfaces.Repositories;
using SharedKernel.Main.ACL.Contracts.Requests;
using SharedKernel.Main.ACL.Contracts.Responses;

namespace SharedKernel.Main.ACL.Domain.Services
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
