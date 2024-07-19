using Microsoft.EntityFrameworkCore;

using Notification.App.Application.Common.Interfaces.Repositories;
using Notification.App.Domain.Notifications.Outgoings;

namespace Notification.App.Infrastructure.Persistence.Repositories;

public class EmailOutgoingRepository(ApplicationDbContext _dbContext) : IEmailOutgoingRepository
{
    public async Task<EmailOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _dbContext.EmailOutgoings.Where(e => e.Id == id).Where(e => e.Status == 0).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}