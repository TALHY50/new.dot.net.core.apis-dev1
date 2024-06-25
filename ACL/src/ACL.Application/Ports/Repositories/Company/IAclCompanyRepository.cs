using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Company;

namespace ACL.Application.Ports.Repositories.Company
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
