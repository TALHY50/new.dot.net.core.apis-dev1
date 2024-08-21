using Microsoft.EntityFrameworkCore;

using SharedKernel.Main.Application.Common.Common.Interfaces.Repositories;
using SharedKernel.Main.Domain.Notification.Notifications.Outgoings;

namespace Notification.App.Infrastructure.Persistence.Repositories;

public class SmsOutgoingRepository(ApplicationDbContext _dbContext) : ISmsOutgoingRepository
{
    public async Task<SmsOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _dbContext.SmsOutgoings.Where(e => e.Id == id).Where(e => e.Status == 0).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}