using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;

namespace ACL.Business.Domain.Services
{
    /// <inheritdoc/>
    public interface IBranchService : IBranchRepository
    {
        /// <inheritdoc/>
        ApplicationResponse Get();
        /// <inheritdoc/>
        ApplicationResponse Add(AclBranchRequest request);
        /// <inheritdoc/>
        ApplicationResponse Edit(uint id, AclBranchRequest request);
        /// <inheritdoc/>
        ApplicationResponse Find(uint id);
        /// <inheritdoc/>
        new ApplicationResponse Delete(uint id);
    }
}
