using ACL.Business.Domain.Entities;

namespace ACL.Business.Application.Interfaces.Repositories

{
    /// <inheritdoc/>
    public interface ICountryRepository
    {
        /// <inheritdoc/>
        bool ExistById(ulong id);
        /// <inheritdoc/>
        List<Country>? All();
        /// <inheritdoc/>
        Country? Find(ulong id);
        /// <inheritdoc/>
        Country? Add(Country country);
        /// <inheritdoc/>
        Country? Update(Country country);
        /// <inheritdoc/>
        Country? Delete(Country country);
        /// <inheritdoc/>
        Country? Delete(ulong id);
    }
}
