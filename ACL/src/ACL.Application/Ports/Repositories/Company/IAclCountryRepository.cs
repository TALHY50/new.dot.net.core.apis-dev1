using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Company;

namespace ACL.Application.Ports.Repositories.Company

{
    /// <inheritdoc/>
    public interface IAclCountryRepository
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
        /// <inheritdoc/>
        bool ExistById(ulong id);
        /// <inheritdoc/>
        List<AclCountry>? All();
        /// <inheritdoc/>
        AclCountry? Find(ulong id);
        /// <inheritdoc/>
        AclCountry? Add(AclCountry aclCountry);
        /// <inheritdoc/>
        AclCountry? Update(AclCountry aclCountry);
        /// <inheritdoc/>
        AclCountry? Delete(AclCountry aclCountry);
        /// <inheritdoc/>
        AclCountry? Delete(ulong id);
    }
}
