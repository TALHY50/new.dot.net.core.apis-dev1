using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Company;

namespace ACL.Application.Ports.Repositories.Company
{
    /// <inheritdoc/>
    public interface IAclStateRepository
    {
        /// <inheritdoc/>
        AclResponse GetAll();
        /// <inheritdoc/>
        AclResponse Add(AclStateRequest stateRequest);
        /// <inheritdoc/>
        AclResponse Edit(ulong id, AclStateRequest stateRequest);
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
        /// <inheritdoc/>
        AclResponse DeleteById(ulong id);
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
