using Microsoft.EntityFrameworkCore;

using Notification.App.Application.Interfaces.Repositories;
using Notification.App.Domain.Entities.Setups;
using Notification.App.Infrastructure.Persistence.Context;

namespace Notification.App.Infrastructure.Persistence.Repositories;

public class CredentialRepository(ApplicationDbContext _dbContext) : ICredentialRepository
{
    public async Task<Credential?> FindByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await Queryable.Where<Credential>(_dbContext.Credentials, e => e.Id == id).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}