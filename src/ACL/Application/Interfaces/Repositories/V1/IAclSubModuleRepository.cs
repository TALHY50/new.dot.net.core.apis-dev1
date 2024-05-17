using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;


namespace ACL.Application.Interfaces.Repositories.V1
{
    /// <inheritdoc/>
    public interface IAclSubModuleRepository
    {
        /// <inheritdoc/>
        Task<AclResponse> GetAll();
        /// <inheritdoc/>
        Task<AclResponse> Add(AclSubModuleRequest subModuleRequest);
        /// <inheritdoc/>
        Task<AclResponse> Edit(ulong id, AclSubModuleRequest subModuleRequest);
        /// <inheritdoc/>
        Task<AclResponse> FindById(ulong id);
        /// <inheritdoc/>
        Task<AclResponse> DeleteById(ulong id);
        /// <inheritdoc/>
        List<AclSubModule>? All();
        /// <inheritdoc/>
        AclSubModule? Find(ulong id);
        /// <inheritdoc/>
        AclSubModule? Add(AclSubModule aclSubModule);
        /// <inheritdoc/>
        AclSubModule? Update(AclSubModule aclSubModule);
        /// <inheritdoc/>
        AclSubModule? Delete(AclSubModule aclSubModule);
        /// <inheritdoc/>
        AclSubModule? Delete(ulong id);
        /// <inheritdoc/>
        bool ExistByName(ulong id, string name);
        /// <inheritdoc/>
        bool ExistById(ulong? id,ulong value);
    }
}
