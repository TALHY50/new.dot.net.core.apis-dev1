using SharedKernel.Main.ACL.Domain.Entities;

namespace SharedKernel.Main.ACL.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface ICompanyModuleRepository
    {
        /// <inheritdoc/>
        List<Company>? All();
        /// <inheritdoc/>
        CompanyModule? Find(ulong id);
        /// <inheritdoc/>
        CompanyModule? Add(CompanyModule aclCompanyModule);
        /// <inheritdoc/>
        CompanyModule? Update(CompanyModule aclCompanyModule);
        /// <inheritdoc/>
        CompanyModule? Delete(CompanyModule aclCompanyModule);
        /// <inheritdoc/>
        CompanyModule? Delete(ulong id);

    }
}
