using SharedKernel.Main.Domain.Notification.Setups;

namespace SharedKernel.Main.Application.Common.Common.Interfaces.Repositories;

public interface ICredentialRepository
{
    Task<Credential?> FindByIdAsync(int id, CancellationToken cancellationToken);
}