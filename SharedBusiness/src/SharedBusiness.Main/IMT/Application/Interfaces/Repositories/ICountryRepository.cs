using Ardalis.SharedKernel;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Repositories;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface ICountryRepository : IRepository<Country>, IExtendedRepositoryBase<Country>
    {
        
    }
}
