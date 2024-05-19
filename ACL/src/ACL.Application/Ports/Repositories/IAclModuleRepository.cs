using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Module;

namespace ACL.Application.Ports.Repositories
{
    /// <inheritdoc/>
    public interface IAclModuleRepository
    {
        /// <inheritdoc/>
        AclResponse GetAll();
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
        /// <inheritdoc/>
        AclResponse AddAclModule(AclModuleRequest request);
        /// <inheritdoc/>
        AclResponse EditAclModule(ulong Id, AclModuleRequest request);
        /// <inheritdoc/>
        AclResponse DeleteModule(ulong id);
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
