using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;

namespace ACL.Business.Domain.Services
{
    public interface ICountryService : ICountryRepository
    {
        /// <inheritdoc/>
        ApplicationResponse GetAll();
        /// <inheritdoc/>
        ApplicationResponse Add(AclCountryRequest countryRequest);
        /// <inheritdoc/>
        ApplicationResponse Edit(uint id, AclCountryRequest countryRequest);
        /// <inheritdoc/>
        ApplicationResponse FindById(uint id);
        /// <inheritdoc/>
        ApplicationResponse DeleteById(uint id);
    }
}
