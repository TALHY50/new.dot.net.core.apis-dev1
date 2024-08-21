using SharedKernel.Main.Domain.Setups;

namespace SharedKernel.Main.Application.Common.Interfaces.Repositories;

public interface ICredentialRepository
{
    Task<Credential?> FindByIdAsync(int id, CancellationToken cancellationToken);
}