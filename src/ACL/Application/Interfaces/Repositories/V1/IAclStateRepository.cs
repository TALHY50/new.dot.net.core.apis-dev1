using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;

namespace ACL.Application.Interfaces.Repositories.V1
{
    /// <inheritdoc/>
    public interface IAclStateRepository
    {
        /// <inheritdoc/>
        Task<AclResponse> GetAll();
        /// <inheritdoc/>
        Task<AclResponse> Add(AclStateRequest stateRequest);
        /// <inheritdoc/>
        Task<AclResponse> Edit(ulong id, AclStateRequest stateRequest);
        /// <inheritdoc/>
        Task<AclResponse> FindById(ulong id);
        /// <inheritdoc/>
        Task<AclResponse> DeleteById(ulong id);
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
        /// <inheritdoc/>
        bool ExistByName(ulong id, string name);

    }
}
