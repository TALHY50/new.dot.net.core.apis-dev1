using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Response;
using ACL.App.Domain.Ports.Repositories.Company;

namespace ACL.App.Domain.Ports.Services.Company
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
