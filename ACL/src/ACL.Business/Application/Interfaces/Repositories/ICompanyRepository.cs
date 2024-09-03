using ACL.Business.Domain.Entities;
using Ardalis.SharedKernel;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface ICompanyRepository : IRepository<Company>, IExtendedRepositoryBase<Company>
    {
       
        List<Company>? All();
        /// <inheritdoc/>
        Company? Find(ulong id);
        /// <inheritdoc/>
        Company? Add(Company aclCompany);
        /// <inheritdoc/>
        Company? Update(Company aclCompany);
        /// <inheritdoc/>
        Company? Delete(Company aclCompany);
        /// <inheritdoc/>
        bool IsCompanyNameUnique(string CompanyName, ulong? CompanyId = null);

    }
}
