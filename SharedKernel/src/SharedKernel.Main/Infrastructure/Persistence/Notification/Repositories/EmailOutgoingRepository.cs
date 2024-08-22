using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Interfaces.Repositories.Notification;
using SharedKernel.Main.Domain.Notification.Notifications.Outgoings;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Context;

namespace SharedKernel.Main.Infrastructure.Persistence.Notification.Repositories;

public class EmailOutgoingRepository(ApplicationDbContext _dbContext) : IEmailOutgoingRepository
{
    public async Task<EmailOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await Queryable.Where<EmailOutgoing>(_dbContext.EmailOutgoings, e => e.Id == id).Where(e => e.Status == 0).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}