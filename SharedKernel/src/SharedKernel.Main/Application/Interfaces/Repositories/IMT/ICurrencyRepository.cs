using SharedKernel.Main.Domain.IMT;

namespace SharedKernel.Main.Application.Interfaces.Repositories.IMT
{
    public interface ICurrencyRepository
    {
        Task<Currency?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
    }
}
