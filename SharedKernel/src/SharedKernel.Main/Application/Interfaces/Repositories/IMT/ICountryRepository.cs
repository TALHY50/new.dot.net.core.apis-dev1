using SharedKernel.Main.Domain.IMT;

namespace SharedKernel.Main.Application.Interfaces.Repositories.IMT
{
    public interface ICountryRepository
    {
        Task<Country?> FindCountryByIdAsync(int id, CancellationToken cancellationToken);

    }
}
