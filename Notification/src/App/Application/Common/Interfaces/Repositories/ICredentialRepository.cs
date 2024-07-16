using ACL.Application.Domain.Setups;

namespace Notification.App.Application.Common.Interfaces.Repositories;

public interface ICredentialRepository
{
    Task<Credential?> FindByIdAsync(int id, CancellationToken cancellationToken);
}