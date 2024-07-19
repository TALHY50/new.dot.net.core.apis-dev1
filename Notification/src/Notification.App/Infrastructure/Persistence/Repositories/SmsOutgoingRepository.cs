using Microsoft.EntityFrameworkCore;

using Notification.App.Application.Common.Interfaces.Repositories;
using Notification.App.Domain.Notifications.Outgoings;

namespace Notification.App.Infrastructure.Persistence.Repositories;

public class SmsOutgoingRepository(ApplicationDbContext _dbContext) : ISmsOutgoingRepository
{
    public async Task<SmsOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _dbContext.SmsOutgoings.Where(e => e.Id == id).Where(e => e.Status == 0).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}