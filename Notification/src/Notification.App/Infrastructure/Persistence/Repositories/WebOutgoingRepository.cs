using Microsoft.EntityFrameworkCore;

using Notification.App.Application.Interfaces.Repositories;
using Notification.App.Domain.Entities.Outgoings;
using Notification.App.Infrastructure.Persistence.Context;

namespace Notification.App.Infrastructure.Persistence.Repositories;

public class WebOutgoingRepository(ApplicationDbContext _dbContext) : IWebOutgoingRepository
{
    public async Task<WebOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await Queryable.Where<WebOutgoing>(_dbContext.WebOutgoings, e => e.Id == id).Where(e => e.Status == 0).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}