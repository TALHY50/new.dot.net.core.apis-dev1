using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;

namespace ACL.Bussiness.Domain.Services
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
