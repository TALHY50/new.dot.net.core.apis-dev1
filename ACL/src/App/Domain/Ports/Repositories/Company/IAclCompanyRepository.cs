using App.Domain.Company;

namespace App.Domain.Ports.Repositories.Company
{
    /// <inheritdoc/>
    public interface IAclCompanyRepository
    {
       
        List<AclCompany>? All();
        /// <inheritdoc/>
        AclCompany? Find(ulong id);
        /// <inheritdoc/>
        AclCompany? Add(AclCompany aclCompany);
        /// <inheritdoc/>
        AclCompany? Update(AclCompany aclCompany);
        /// <inheritdoc/>
        AclCompany? Delete(AclCompany aclCompany);
        /// <inheritdoc/>
        bool IsCompanyNameUnique(string CompanyName, ulong? CompanyId = null);

    }
}
