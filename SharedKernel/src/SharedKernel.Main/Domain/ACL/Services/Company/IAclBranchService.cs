using SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.Company;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;

namespace SharedKernel.Main.Domain.ACL.Services.Company
{
    /// <inheritdoc/>
    public interface IAclBranchService : IAclBranchRepository
    {
        /// <inheritdoc/>
        AclResponse Get();
        /// <inheritdoc/>
        AclResponse Add(AclBranchRequest request);
        /// <inheritdoc/>
        AclResponse Edit(ulong id, AclBranchRequest request);
        /// <inheritdoc/>
        AclResponse Find(ulong id);
        /// <inheritdoc/>
        new AclResponse Delete(ulong id);
    }
}
