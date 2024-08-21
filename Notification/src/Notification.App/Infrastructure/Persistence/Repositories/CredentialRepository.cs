using Microsoft.EntityFrameworkCore;

using Notification.App.Application.Common.Interfaces.Repositories;
using Notification.App.Domain.Setups;

namespace Notification.App.Infrastructure.Persistence.Repositories;

public class CredentialRepository(ApplicationDbContext _dbContext) : ICredentialRepository
{
    public async Task<Credential?> FindByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Credentials.Where(e => e.Id == id).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}