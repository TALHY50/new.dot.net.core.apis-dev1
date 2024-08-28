using Notification.App.Domain.Entities.Outgoings;

namespace Notification.App.Application.Interfaces.Repositories;

public interface ISmsOutgoingRepository
{
    Task<SmsOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}