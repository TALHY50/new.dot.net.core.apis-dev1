using Microsoft.EntityFrameworkCore;

using SharedKernel.Main.Application.Common.Common.Interfaces.Repositories;
using SharedKernel.Main.Domain.Notification.Setups;

namespace Notification.App.Infrastructure.Persistence.Repositories;

public class CredentialRepository(ApplicationDbContext _dbContext) : ICredentialRepository
{
    public async Task<Credential?> FindByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Credentials.Where(e => e.Id == id).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}