using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1
{
    /// <inheritdoc/>
    public interface IAclUserGroupRoleRepository
    {
        /// <inheritdoc/>
        Task<AclResponse> GetRolesByUserGroupId(ulong groupId);
        /// <inheritdoc/>
        Task<AclResponse> Update(AclUserGroupRoleRequest userGroupRole);
        /// <inheritdoc/>
        List<AclUsergroupRole>? All();
        /// <inheritdoc/>
        AclUsergroupRole? Find(ulong id);
        /// <inheritdoc/>
        AclUsergroupRole? Add(AclUsergroupRole aclCompany);
        /// <inheritdoc/>
        AclUsergroupRole? Update(AclUsergroupRole aclCompany);
        /// <inheritdoc/>
        AclUsergroupRole? Delete(AclUsergroupRole aclCompany);
        /// <inheritdoc/>
        AclUsergroupRole? Delete(ulong id);
    }
}
