using System.Net.Mime;

using Microsoft.EntityFrameworkCore;

using SharedKernel.Main.Application.Common.Common.Interfaces.Repositories;
using SharedKernel.Main.Domain.Notification.Notifications.Outgoings;

namespace Notification.App.Infrastructure.Persistence.Repositories;

public class WebOutgoingRepository(ApplicationDbContext _dbContext) : IWebOutgoingRepository
{
    public async Task<WebOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _dbContext.WebOutgoings.Where(e => e.Id == id).Where(e => e.Status == 0).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}