using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;

namespace ACL.App.Domain.Services
{
    public interface ICountryService : ICountryRepository
    {
        /// <inheritdoc/>
        ScopeResponse GetAll();
        /// <inheritdoc/>
        ScopeResponse Add(AclCountryRequest countryRequest);
        /// <inheritdoc/>
        ScopeResponse Edit(ulong id, AclCountryRequest countryRequest);
        /// <inheritdoc/>
        ScopeResponse FindById(ulong id);
        /// <inheritdoc/>
        ScopeResponse DeleteById(ulong id);
    }
}
