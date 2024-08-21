using SharedKernel.Main.Domain.Notification.Setups;

namespace SharedKernel.Main.Application.Common.Interfaces.Notification;

public interface ICredentialRepository
{
    Task<Credential?> FindByIdAsync(int id, CancellationToken cancellationToken);
}