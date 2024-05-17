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
        AclUserUsergroup? Add(AclUserUsergroup aclCompany);
        /// <inheritdoc/>
        AclUserUsergroup? Update(AclUserUsergroup aclCompany);
        /// <inheritdoc/>
        AclUserUsergroup? Delete(AclUserUsergroup aclCompany);
        /// <inheritdoc/>
        AclUserUsergroup? Delete(ulong id);
    }
}
