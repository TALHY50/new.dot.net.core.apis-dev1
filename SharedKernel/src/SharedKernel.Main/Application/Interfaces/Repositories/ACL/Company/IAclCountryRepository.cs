using SharedKernel.Main.Domain.ACL.Domain.Company;

namespace SharedKernel.Main.Application.Interfaces.Repositories.ACL.Company

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
