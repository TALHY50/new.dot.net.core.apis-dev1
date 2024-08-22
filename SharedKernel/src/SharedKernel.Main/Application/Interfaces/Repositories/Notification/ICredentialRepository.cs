using SharedKernel.Main.Domain.Notification.Setups;

namespace SharedKernel.Main.Application.Interfaces.Repositories.Notification;

public interface ICredentialRepository
{
    Task<Credential?> FindByIdAsync(int id, CancellationToken cancellationToken);
}