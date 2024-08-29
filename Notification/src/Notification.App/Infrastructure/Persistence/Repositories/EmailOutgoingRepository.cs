using Microsoft.EntityFrameworkCore;

using Notification.App.Application.Interfaces.Repositories;
using Notification.App.Domain.Entities.Outgoings;
using Notification.App.Infrastructure.Persistence.Context;

namespace Notification.App.Infrastructure.Persistence.Repositories;

public class EmailOutgoingRepository(ApplicationDbContext _dbContext) : IEmailOutgoingRepository
{
    public async Task<EmailOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await Queryable.Where<EmailOutgoing>(_dbContext.EmailOutgoings, e => e.Id == id).Where(e => e.Status == 0).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}