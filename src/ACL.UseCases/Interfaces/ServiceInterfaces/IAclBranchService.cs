using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.UseCases.Interfaces.Repositories.V1;

namespace ACL.UseCases.Interfaces.ServiceInterfaces
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
