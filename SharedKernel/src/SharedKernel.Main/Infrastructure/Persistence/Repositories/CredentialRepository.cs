using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Common.Interfaces.Notification;
using SharedKernel.Main.Domain.Notification.Setups;

namespace SharedKernel.Main.Infrastructure.Persistence.Repositories;

public class CredentialRepository(ApplicationDbContext _dbContext) : ICredentialRepository
{
    public async Task<Credential?> FindByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await Queryable.Where<Credential>(_dbContext.Credentials, e => e.Id == id).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}