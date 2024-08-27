using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Notification.Application.Interfaces.Repositories;
using SharedKernel.Main.Notification.Domain.Entities.Setups;
using SharedKernel.Main.Notification.Infrastructure.Persistence.Context;

namespace SharedKernel.Main.Notification.Infrastructure.Persistence.Repositories;

public class CredentialRepository(ApplicationDbContext _dbContext) : ICredentialRepository
{
    public async Task<Credential?> FindByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await Queryable.Where<Credential>(_dbContext.Credentials, e => e.Id == id).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}