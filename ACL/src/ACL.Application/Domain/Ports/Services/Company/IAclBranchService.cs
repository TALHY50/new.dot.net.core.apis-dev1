using ACL.Application.Contracts.Requests;
using ACL.Application.Contracts.Response;
using ACL.Application.Domain.Ports.Repositories.Company;

namespace ACL.Application.Domain.Ports.Services.Company
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
