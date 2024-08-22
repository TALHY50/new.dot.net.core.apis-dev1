using SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.Company;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;

namespace SharedKernel.Main.Domain.ACL.Services.Company
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
