using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1

{
    /// <inheritdoc/>
    public interface IAclRoleRepository
    {
        /// <inheritdoc/>
        Task<AclResponse> GetAll();
        /// <inheritdoc/>
        Task<AclResponse> Add(AclRoleRequest roleRequest);
        /// <inheritdoc/>
        Task<AclResponse> Edit(ulong id, AclRoleRequest roleRequest);
        /// <inheritdoc/>
        Task<AclResponse> FindById(ulong id);
        /// <inheritdoc/>
        Task<AclResponse> Delete(ulong id);
        /// <inheritdoc/>
        List<AclRole>? All();
        /// <inheritdoc/>
        AclRole? Find(ulong id);
        /// <inheritdoc/>
        AclRole? Add(AclRole aclRole);
        /// <inheritdoc/>
        AclRole? Update(AclRole aclRole);
        /// <inheritdoc/>
        AclRole? Delete(AclRole aclRole);
        /// <inheritdoc/>
        AclRole? Deleted(ulong id);
    }
}
