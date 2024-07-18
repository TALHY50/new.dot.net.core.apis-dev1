using App.Domain.Company;

namespace App.Domain.Ports.Repositories.Company

{
    /// <inheritdoc/>
    public interface IAclCountryRepository
    {
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
