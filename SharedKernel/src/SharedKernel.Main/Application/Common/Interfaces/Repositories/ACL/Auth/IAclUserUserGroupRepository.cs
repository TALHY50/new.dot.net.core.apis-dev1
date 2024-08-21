using SharedKernel.Main.Domain.ACL.Domain.Auth;

namespace SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.Auth
{
    /// <inheritdoc/>
    public interface IAclUserUserGroupRepository
    {
        /// <inheritdoc/>
        List<AclUserUsergroup>? All();
        /// <inheritdoc/>
        AclUserUsergroup? Find(ulong id);
        /// <inheritdoc/>
        AclUserUsergroup? Add(AclUserUsergroup acluseruserGroup);
        /// <inheritdoc/>
        AclUserUsergroup? Update(AclUserUsergroup aclUserUserGroup);
        /// <inheritdoc/>
        AclUserUsergroup? Delete(AclUserUsergroup aclUserUserGroup);
        /// <inheritdoc/>
        AclUserUsergroup? Delete(ulong id);
        /// <inheritdoc/>
        AclUserUsergroup[]? AddRange( AclUserUsergroup[]? userUserGroups);
        /// <inheritdoc/>
        AclUserUsergroup[]? RemoveRange( AclUserUsergroup[] userUserGroups);
        /// <inheritdoc/>
        AclUserUsergroup[]? Where(ulong userid);
        /// <inheritdoc/>
        AclUserUsergroup PrepareDataForInput(ulong userGroup, ulong userId);
    }
}
