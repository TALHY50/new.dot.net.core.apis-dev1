using Notification.App.Domain.Entities.Setups;

namespace Notification.App.Application.Interfaces.Repositories;

public interface ICredentialRepository
{
    Task<Credential?> FindByIdAsync(int id, CancellationToken cancellationToken);
}