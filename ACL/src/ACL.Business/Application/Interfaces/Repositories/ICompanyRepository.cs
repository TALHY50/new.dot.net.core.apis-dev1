using ACL.Business.Domain.Entities;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface ICompanyRepository
    {
       
        List<Company>? All();
        /// <inheritdoc/>
        Company? Find(uint id);
        /// <inheritdoc/>
        Company? Add(Company aclCompany);
        /// <inheritdoc/>
        Company? Update(Company aclCompany);
        /// <inheritdoc/>
        Company? Delete(Company aclCompany);
        /// <inheritdoc/>
        bool IsCompanyNameUnique(string CompanyName, uint? CompanyId = null);

    }
}
