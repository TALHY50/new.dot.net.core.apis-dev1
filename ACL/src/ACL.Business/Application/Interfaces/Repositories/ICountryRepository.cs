using ACL.Business.Domain.Entities;
using Ardalis.SharedKernel;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace ACL.Business.Application.Interfaces.Repositories

{
    /// <inheritdoc/>
    public interface ICountryRepository : IRepository<Country>, IExtendedRepositoryBase<Country>
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
