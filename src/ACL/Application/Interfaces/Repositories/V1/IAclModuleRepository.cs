using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;


namespace ACL.Application.Interfaces.Repositories.V1
{
    /// <inheritdoc/>
    public interface IAclModuleRepository
    {
        /// <inheritdoc/>
        Task<AclResponse> GetAll();
        /// <inheritdoc/>
        Task<AclResponse> FindById(ulong id);
        /// <inheritdoc/>
        Task<AclResponse> AddAclModule(AclModuleRequest request);
        /// <inheritdoc/>
        Task<AclResponse> EditAclModule(ulong Id, AclModuleRequest request);
        /// <inheritdoc/>
        Task<AclResponse> DeleteModule(ulong id);
        /// <inheritdoc/>
        List<AclModule>? All();
        /// <inheritdoc/>
        AclModule? Find(ulong id);
        /// <inheritdoc/>
        AclModule? Add(AclModule aclModule);
        /// <inheritdoc/>
        AclModule? Update(AclModule aclModule);
        /// <inheritdoc/>
        AclModule? Delete(AclModule aclModule);
        /// <inheritdoc/>
        AclModule? Delete(ulong id);
        /// <inheritdoc/>
        bool ExistByName(ulong id, string name);
        /// <inheritdoc/>
        bool ExistById(ulong? id, ulong value);
    }
}
