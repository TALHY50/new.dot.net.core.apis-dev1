using SharedKernel.Main.Domain.ACL.Domain.Company;

namespace SharedKernel.Main.Application.Interfaces.Repositories.ACL.Company
{
    /// <inheritdoc/>
    public interface IAclStateRepository
    {
        /// <inheritdoc/>
        List<AclState>? All();
        /// <inheritdoc/>
        AclState? Find(ulong id);
        /// <inheritdoc/>
        AclState? Add(AclState aclState);
        /// <inheritdoc/>
        AclState? Update(AclState aclState);
        /// <inheritdoc/>
        AclState? Delete(AclState aclState);
        /// <inheritdoc/>
        AclState? Delete(ulong id);


    }
}
