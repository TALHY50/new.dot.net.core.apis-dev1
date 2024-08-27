using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Notification.Application.Interfaces.Repositories;
using SharedKernel.Main.Notification.Domain.Entities.Outgoings;
using SharedKernel.Main.Notification.Infrastructure.Persistence.Context;

namespace SharedKernel.Main.Notification.Infrastructure.Persistence.Repositories;

public class WebOutgoingRepository(ApplicationDbContext _dbContext) : IWebOutgoingRepository
{
    public async Task<WebOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await Queryable.Where<WebOutgoing>(_dbContext.WebOutgoings, e => e.Id == id).Where(e => e.Status == 0).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}