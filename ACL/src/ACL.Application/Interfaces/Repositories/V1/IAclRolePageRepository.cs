using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Entities;

namespace ACL.Application.Interfaces.Repositories.V1
{
    /// <inheritdoc/>
    public interface IAclRolePageRepository
    {
        /// <inheritdoc/>
        Task<AclResponse> GetAllById(ulong Id);
        /// <inheritdoc/>
        Task<AclResponse> UpdateAll(AclRoleAndPageAssocUpdateRequest rolePageAssociationRequest);
        /// <inheritdoc/>
        AclRolePage[] PrepareData(AclRoleAndPageAssocUpdateRequest rolePageAssociationRequest);
        /// <inheritdoc/>
        List<AclRolePage>? All();
        /// <inheritdoc/>
        AclRolePage? Find(ulong id);
        /// <inheritdoc/>
        AclRolePage? Add(AclRolePage aclRolePage);
        /// <inheritdoc/>
        AclRolePage? Update(AclRolePage aclRolePage);
        /// <inheritdoc/>
        AclRolePage? Delete(AclRolePage aclRolePage);
        /// <inheritdoc/>
        AclPageRoute? Delete(ulong id);
        /// <inheritdoc/>
        AclRolePage[]? AddAll(AclRolePage[] aclRolePages);
        /// <inheritdoc/>
        AclRolePage[]? DeleteAll(AclRolePage[] aclRolePages);
        /// <inheritdoc/>
        AclRolePage[]? DeleteAllByRoleId(ulong roleId);
    }
}
