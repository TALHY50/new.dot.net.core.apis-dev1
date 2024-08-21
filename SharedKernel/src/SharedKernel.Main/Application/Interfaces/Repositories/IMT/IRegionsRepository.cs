using SharedKernel.Main.Domain.IMT;

namespace SharedKernel.Main.Application.Interfaces.Repositories.IMT
{
    public interface IRegionsRepository
    {
        Task<Regions?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
    }
}
