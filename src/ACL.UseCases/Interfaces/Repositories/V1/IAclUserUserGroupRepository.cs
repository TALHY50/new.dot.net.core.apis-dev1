using ACL.Core.Models;

namespace ACL.UseCases.Interfaces.Repositories.V1
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
        AclUserUsergroup? Update(AclUserUsergroup acluseruserGroup);
        /// <inheritdoc/>
        AclUserUsergroup? Delete(AclUserUsergroup acluseruserGroup);
        /// <inheritdoc/>
        AclUserUsergroup? Delete(ulong id);
        /// <inheritdoc/>
        AclUserUsergroup[]? AddRange( AclUserUsergroup[]? userUsergroups);
        /// <inheritdoc/>
        AclUserUsergroup[]? RemoveRange( AclUserUsergroup[] userUsergroups);
        /// <inheritdoc/>
        AclUserUsergroup[]? Where(ulong userid);
    }
}
