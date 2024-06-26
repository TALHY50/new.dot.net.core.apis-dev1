using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Company;

namespace ACL.Application.Ports.Repositories.Company
{
    /// <inheritdoc/>
    public interface IAclCompanyModuleRepository
    {
        /// <inheritdoc/>
        List<AclCompany>? All();
        /// <inheritdoc/>
        AclCompanyModule? Find(ulong id);
        /// <inheritdoc/>
        AclCompanyModule? Add(AclCompanyModule aclCompanyModule);
        /// <inheritdoc/>
        AclCompanyModule? Update(AclCompanyModule aclCompanyModule);
        /// <inheritdoc/>
        AclCompanyModule? Delete(AclCompanyModule aclCompanyModule);
        /// <inheritdoc/>
        AclCompanyModule? Delete(ulong id);

    }
}
