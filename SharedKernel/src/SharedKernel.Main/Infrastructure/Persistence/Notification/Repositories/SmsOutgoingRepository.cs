using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Interfaces.Repositories.Notification;
using SharedKernel.Main.Domain.Notification.Notifications.Outgoings;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Context;

namespace SharedKernel.Main.Infrastructure.Persistence.Notification.Repositories;

public class SmsOutgoingRepository(ApplicationDbContext _dbContext) : ISmsOutgoingRepository
{
    public async Task<SmsOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await Queryable.Where<SmsOutgoing>(_dbContext.SmsOutgoings, e => e.Id == id).Where(e => e.Status == 0).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}