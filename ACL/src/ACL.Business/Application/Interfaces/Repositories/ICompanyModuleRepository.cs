using ACL.Business.Domain.Entities;
using Ardalis.SharedKernel;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface ICompanyModuleRepository : IRepository<CompanyModule>, IExtendedRepositoryBase<CompanyModule>
    {
        /// <inheritdoc/>
        List<CompanyModule>? All();
        /// <inheritdoc/>
        CompanyModule? Find(uint id);
        /// <inheritdoc/>
        CompanyModule? Add(CompanyModule aclCompanyModule);
        /// <inheritdoc/>
        CompanyModule? Update(CompanyModule aclCompanyModule);
        /// <inheritdoc/>
        CompanyModule? Delete(CompanyModule aclCompanyModule);
        /// <inheritdoc/>
        CompanyModule? Delete(uint id);

    }
}
