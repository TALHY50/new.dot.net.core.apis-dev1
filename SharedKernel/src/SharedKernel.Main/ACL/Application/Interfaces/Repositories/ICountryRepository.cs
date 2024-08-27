using SharedKernel.Main.ACL.Domain.Entities;

namespace SharedKernel.Main.ACL.Application.Interfaces.Repositories

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
