using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1
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
    }
}
