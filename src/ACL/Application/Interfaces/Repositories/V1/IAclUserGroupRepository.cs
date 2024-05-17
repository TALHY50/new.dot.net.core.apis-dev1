using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1
{
    /// <inheritdoc/>
    public interface IAclUserGroupRepository
    {
        /// <inheritdoc/>
        Task<AclResponse> GetAll();
        /// <inheritdoc/>
        Task<AclResponse> AddUserGroup(AclUserGroupRequest userGroupRequest);
        /// <inheritdoc/>
        Task<AclResponse> UpdateUserGroup(ulong id, AclUserGroupRequest userGroupRequest);
        /// <inheritdoc/>
        Task<AclResponse> FindById(ulong id);
        /// <inheritdoc/>
        Task<AclResponse> Delete(ulong id);
        /// <inheritdoc/>
        AclUsergroup PrepareInputData(AclUserGroupRequest userGroupRequest, AclUsergroup aclCompany = null);
        /// <inheritdoc/>
        ulong SetCompanyId(ulong companyId);
        /// <inheritdoc/>
        List<AclUsergroup>? All();
        /// <inheritdoc/>
        AclUsergroup? Find(ulong id);
        /// <inheritdoc/>
        AclUsergroup? Add(AclUsergroup aclUsergroup);
        /// <inheritdoc/>
        AclUsergroup? Update(AclUsergroup aclUsergroup);
        /// <inheritdoc/>
        AclUsergroup? Delete(AclUsergroup aclUsergroup);
        /// <inheritdoc/>
        AclUsergroup? Deleted(ulong id);
    }
}
