using SharedKernel.Main.Domain.ACL.Domain.Company;

namespace SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.Company
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
