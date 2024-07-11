using Notification.Application.Contracts.Requests;
using Notification.Application.Contracts.Response;
using Notification.Application.Domain.Ports.Repositories.Company;

namespace ACL.Application.Domain.Ports.Services.Company
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
