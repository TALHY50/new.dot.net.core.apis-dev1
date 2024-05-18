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
       AclResponse GetAll();
        /// <inheritdoc/>
        AclResponse Add(AclRoleRequest roleRequest);
        /// <inheritdoc/>
        AclResponse Edit(ulong id, AclRoleRequest roleRequest);
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
        /// <inheritdoc/>
        AclResponse DeleteById(ulong id);
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
        AclRole? Delete(ulong id);
    }
}
