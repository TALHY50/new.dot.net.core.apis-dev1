using System.Net.Mime;

using Microsoft.EntityFrameworkCore;

using Notification.App.Application.Common.Interfaces.Repositories;
using Notification.App.Domain.Notifications.Outgoings;

namespace Notification.App.Infrastructure.Persistence.Repositories;

public class WebOutgoingRepository(ApplicationDbContext _dbContext) : IWebOutgoingRepository
{
    public async Task<WebOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _dbContext.WebOutgoings.Where(e => e.Id == id).Where(e => e.Status == 0).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}