using ACL.App.Domain.Entities;

namespace ACL.App.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface ICompanyRepository
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
