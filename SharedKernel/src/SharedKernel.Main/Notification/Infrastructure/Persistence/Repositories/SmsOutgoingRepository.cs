using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Notification.Application.Interfaces.Repositories;
using SharedKernel.Main.Notification.Domain.Entities.Outgoings;
using SharedKernel.Main.Notification.Infrastructure.Persistence.Context;

namespace SharedKernel.Main.Notification.Infrastructure.Persistence.Repositories;

public class SmsOutgoingRepository(ApplicationDbContext _dbContext) : ISmsOutgoingRepository
{
    public async Task<SmsOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await Queryable.Where<SmsOutgoing>(_dbContext.SmsOutgoings, e => e.Id == id).Where(e => e.Status == 0).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}