using ACL.App.Application.Interfaces.Repositories.Company;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;

namespace ACL.App.Application.Interfaces.Services.Company
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
