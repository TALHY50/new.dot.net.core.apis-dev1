using ACL.Application.Domain.Setups;

namespace Notification.Main.Application.Common.Interfaces.Repositories;

public interface ICredentialRepository
{
    Task<Credential?> FindByIdAsync(int id, CancellationToken cancellationToken);
}