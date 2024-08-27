using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Notification.Application.Interfaces.Repositories;
using SharedKernel.Main.Notification.Domain.Entities.Outgoings;
using SharedKernel.Main.Notification.Infrastructure.Persistence.Context;

namespace SharedKernel.Main.Notification.Infrastructure.Persistence.Repositories;

public class EmailOutgoingRepository(ApplicationDbContext _dbContext) : IEmailOutgoingRepository
{
    public async Task<EmailOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await Queryable.Where<EmailOutgoing>(_dbContext.EmailOutgoings, e => e.Id == id).Where(e => e.Status == 0).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}