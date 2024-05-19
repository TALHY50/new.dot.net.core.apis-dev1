using ACL.Application.Ports.Repositories;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;

namespace ACL.Application.Ports.Services
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
