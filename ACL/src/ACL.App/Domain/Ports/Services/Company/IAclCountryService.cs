using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Response;
using ACL.App.Domain.Ports.Repositories.Company;

namespace ACL.App.Domain.Ports.Services.Company
{
    public interface IAclCountryService : IAclCountryRepository
    {
        /// <inheritdoc/>
        AclResponse GetAll();
        /// <inheritdoc/>
        AclResponse Add(AclCountryRequest countryRequest);
        /// <inheritdoc/>
        AclResponse Edit(ulong id, AclCountryRequest countryRequest);
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
        /// <inheritdoc/>
        AclResponse DeleteById(ulong id);
    }
}
