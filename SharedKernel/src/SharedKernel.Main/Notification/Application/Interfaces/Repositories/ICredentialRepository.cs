using SharedKernel.Main.Notification.Domain.Entities.Setups;

namespace SharedKernel.Main.Notification.Application.Interfaces.Repositories;

public interface ICredentialRepository
{
    Task<Credential?> FindByIdAsync(int id, CancellationToken cancellationToken);
}