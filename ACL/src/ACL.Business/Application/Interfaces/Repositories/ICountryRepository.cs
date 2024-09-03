using ACL.Business.Domain.Entities;
using Ardalis.SharedKernel;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace ACL.Business.Application.Interfaces.Repositories

{
    /// <inheritdoc/>
    public interface ICountryRepository : IRepository<Country>, IExtendedRepositoryBase<Country>
    {
        /// <inheritdoc/>
        bool ExistById(uint id);
        /// <inheritdoc/>
        List<Country>? All();
        /// <inheritdoc/>
        Country? Find(uint id);
        /// <inheritdoc/>
        Country? Add(Country country);
        /// <inheritdoc/>
        Country? Update(Country country);
        /// <inheritdoc/>
        Country? Delete(Country country);
        /// <inheritdoc/>
        Country? Delete(uint id);
    }
}
