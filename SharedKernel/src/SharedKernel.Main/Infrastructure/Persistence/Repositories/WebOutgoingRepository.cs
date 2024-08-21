using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Common.Interfaces.Notification;
using SharedKernel.Main.Domain.Notification.Notifications.Outgoings;

namespace SharedKernel.Main.Infrastructure.Persistence.Repositories;

public class WebOutgoingRepository(ApplicationDbContext _dbContext) : IWebOutgoingRepository
{
    public async Task<WebOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await Queryable.Where<WebOutgoing>(_dbContext.WebOutgoings, e => e.Id == id).Where(e => e.Status == 0).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}